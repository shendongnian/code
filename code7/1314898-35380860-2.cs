    private const int ProcessingSize= 4;
    private static readonly HttpClient HttpClient = new HttpClient();
    private TransformBlock<string, DataType> _processingBlock;
    private BufferBlock<DataType> _messageBufferBlock;
    public Task ProduceAsync()
    {
      PrepareDataflow(token);
      ListFiles(_fileBufferBlock, token);
      _processingBlock.Complete();
      return _processingBlock.Completion;
    }
    private void ListFiles(ITargetBlock<string> targetBlock, CancellationToken token)
    {
      ... // Get list of file Uris, occasionally calling token.ThrowIfCancellationRequested()
      foreach(var fileNameUri in fileNameUris)
        _processingBlock.Post(fileNameUri);
    }
    private async Task<IEnumerable<DataType>> ProcessFileAsync(string fileNameUri, CancellationToken token)
    {
      return Process(await HttpClient.GetStreamAsync(fileNameUri), token);
    }
    private IEnumerable<DataType> Process(Stream stream, CancellationToken token)
    {
      using (stream)
      using (var sr = new StreamReader(stream))
      using (var jsonTextReader = new JsonTextReader(sr))
      {
        while (jsonTextReader.Read())
        {
          token.ThrowIfCancellationRequested();
          if (jsonTextReader.TokenType == JsonToken.StartObject)
          {
            try
            {
              yield _jsonSerializer.Deserialize<DataType>(jsonTextReader);
            }
            catch (Exception ex)
            {
              _logger.Error(ex, $"JSON deserialization failed - {fileNameUri}");
            }
          }
        }
      }
    }
    private void PrepareDataflow(CancellationToken token)
    {
      var executeOptions = new ExecutionDataflowBlockOptions
      {
        CancellationToken = token,
        MaxDegreeOfParallelism = ProcessingSize
      };
      _processingBlock = new TransformManyBlock<string, DataType>(fileName =>
          ProcessFileAsync(fileName, token), executeOptions);
      _messageBufferBlock = new BufferBlock<DataType>(new DataflowBlockOptions
      {
        CancellationToken = token,
        BoundedCapacity = 50000
      });
    }

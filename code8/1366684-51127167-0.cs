    public async Task RecordAsync(ISpecificRecord record, string partitionKey)
        {
            using (var ms = new MemoryStream())
            {
                var encoder = new BinaryEncoder(ms);
                var writer = new SpecificDefaultWriter(record.Schema);
                writer.Write(record, encoder);
                // AWS Kineses 
                var putRecordRequest = new PutRecordRequest
                {
                    StreamName = _streamName,
                    Data = ms,
                    PartitionKey = partitionKey
                };
                await _kinesis.PutRecordAsync(putRecordRequest);
            }
        }

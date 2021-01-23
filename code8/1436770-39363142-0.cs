    void Main()
    {
    	//create the service and auth
    	CloudSpeechAPIService service = new CloudSpeechAPIService(new BaseClientService.Initializer
    	{
    		ApplicationName = "Speech API Test",
    		ApiKey = "your API key..."
    	});
    	
    	//configure the audio file properties
    	RecognitionConfig sConfig = new RecognitionConfig();
    	sConfig.Encoding = "FLAC";
    	sConfig.SampleRate = 16000;
    	sConfig.LanguageCode = "en-AU";
    
    	//make the request and output the transcribed text to console
    	SyncRecognizeResponse response = getResponse(service, sConfig, "audio file.flac");
    	string resultText = response.Results.ElementAt(0).Alternatives.ElementAt(0).Transcript;
    	Console.WriteLine(resultText);
    }
    
    
    public SyncRecognizeResponse getResponse(CloudSpeechAPIService sService, RecognitionConfig sConfig, string fileName)
    {
    	//read the audio file into a base 64 string and add to API object
    	RecognitionAudio sAudio = new RecognitionAudio();
    	byte[] audioBytes = getAudioStreamBytes(fileName);
    	sAudio.Content = Convert.ToBase64String(audioBytes);
    
    	//create the request with the config and audio files
    	SyncRecognizeRequest sRequest = new SyncRecognizeRequest();
    	sRequest.Config = sConfig;
    	sRequest.Audio = sAudio;
    
    	//execute the request
    	SyncRecognizeResponse response = sService.Speech.Syncrecognize(sRequest).Execute();
    	
    	return response;
    }
    
    
    public byte[] getAudioStreamBytes(string fileName)
    {
    	FileStream fileStream = File.OpenRead(fileName);
    	MemoryStream memoryStream = new MemoryStream();
    	memoryStream.SetLength(fileStream.Length);
    	fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
    	byte[] BA_AudioFile = memoryStream.GetBuffer();
    	return BA_AudioFile;
    }

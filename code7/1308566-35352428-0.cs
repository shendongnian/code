    string api_key = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
    string path = @"C:\temp\good-morning-google.flac";
    byte[] bytes = System.IO.File.ReadAllBytes(path);
    WebClient client = new WebClient();
    client.Headers.Add("Content-Type", "audio/x-flac; rate=44100");
    byte[] result = client.UploadData(string.Format(
				"https://www.google.com/speech-api/v2/recognize?client=chromium&lang=en-us&key={0}", api_key), "POST", bytes);
    string s = client.Encoding.GetString(result);

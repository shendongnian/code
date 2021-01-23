    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    namespace GoogleAPI{
    
        public class GoogleSpeech
            {
                public string URL { get; set; }
        
                public void GetSpeechTranscript(string filePath)
                {
                    try
                    {
        
                        FileStream fileStream = File.OpenRead(filePath);
                        MemoryStream memoryStream = new MemoryStream();
                        memoryStream.SetLength(fileStream.Length);
                        fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
                        byte[] resBytes = memoryStream.GetBuffer();
                        HttpWebRequest request = null;
                        request = (HttpWebRequest)HttpWebRequest.Create(this.URL + "&key=YOUR_API_KEY");
                        request.Credentials = CredentialCache.DefaultCredentials;
                        request.Method = "POST";
                        request.ContentType = "audio/x-flac; rate=44100";
                        request.ContentLength = BA_AudioFile.Length;
                        Stream stream = request.GetRequestStream();
                        stream.Write(resBytes, 0, resBytes.Length);
                        stream.Close();
        
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader reqStream = new StreamReader(response.GetResponseStream());
                            var result = reqStream.ReadToEnd();
                            Console.WriteLine(result);
                        }
        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
        
                    Console.ReadLine();
                }
            }
    }

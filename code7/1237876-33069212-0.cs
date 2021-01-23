     FileStream fileStream = File.OpenRead(data_to_translate);
                MemoryStream memoryStream = new MemoryStream();
                memoryStream.SetLength(fileStream.Length);
                fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
                byte[] BA_AudioFile = memoryStream.GetBuffer();
                HttpWebRequest _HWR_SpeechToText = null;
                _HWR_SpeechToText =
                                    (HttpWebRequest)HttpWebRequest.Create("https://stream.watsonplatform.net/speech-to-text/api/v1/recognize");
                string auth = string.Format("{0}:{1}","Watson.uID","Watson_uPWD");
                string auth64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));
                string credentials = string.Format("{0} {1}", "Basic", auth64);
                
                _HWR_SpeechToText.Headers[HttpRequestHeader.Authorization] = credentials;
                _HWR_SpeechToText.Method = "POST";
                _HWR_SpeechToText.ContentType = "audio/flac; rate=44100; channels=2;";
                _HWR_SpeechToText.ContentLength = BA_AudioFile.Length;
                Stream stream = _HWR_SpeechToText.GetRequestStream();
                stream.Write(BA_AudioFile, 0, BA_AudioFile.Length);
                stream.Close();
                HttpWebResponse HWR_Response = (HttpWebResponse)_HWR_SpeechToText.GetResponse();
                if (HWR_Response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader SR_Response = new StreamReader(HWR_Response.GetResponseStream());
                    var result = SR_Response.ReadToEnd();
                    Console.WriteLine(result);
                    var jsons = SR_Response.ReadToEnd();

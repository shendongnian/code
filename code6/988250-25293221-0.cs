    public string audioStreamToText(RecognitionResult result)
            MemoryStream audioStream = new MemoryStream();            
            result.Audio.WriteToWaveStream(audioStream);
            byte[] BA_AudioFile = audioStream.GetBuffer();
            HttpWebRequest _HWR_SpeechToText = null;
            _HWR_SpeechToText = (HttpWebRequest)WebRequest.Create("https://www.google.com/speech-api/v2/recognize?output=json&lang=en-us&key=YOUR_API_KEY_HERE");
            _HWR_SpeechToText.Method = "POST";
            _HWR_SpeechToText.ContentType = "audio/l16; rate=16000";
            _HWR_SpeechToText.ContentLength = (long)((int)BA_AudioFile.Length);
            _HWR_SpeechToText.GetRequestStream().Write(BA_AudioFile, 0, (int)BA_AudioFile.Length);
            HttpWebResponse HWR_Response = (HttpWebResponse)_HWR_SpeechToText.GetResponse();
            
            if (HWR_Response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader SR_Response = new StreamReader(HWR_Response.GetResponseStream());
                return SR_Response.ReadToEnd();
            }
            return null;
        }

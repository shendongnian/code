        public Stream Speak(string text)
        {
            OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
            SpeechSynthesizer synth = new SpeechSynthesizer();
            MemoryStream ms = new MemoryStream();
            synth.Rate = 1;
            synth.Volume = 100;
            synth.SelectVoice("Microsoft Maria Desktop");
            synth.SetOutputToWaveStream(ms);
            synth.Speak(text);
            synth.SetOutputToNull();
            context.Headers.Add(System.Net.HttpResponseHeader.CacheControl, "public");
            context.ContentType = "audio/wav";
            context.StatusCode = System.Net.HttpStatusCode.OK;
            
            ms.Position = 0;    // <<<------------ That's the secret!!!
            return ms;
        }

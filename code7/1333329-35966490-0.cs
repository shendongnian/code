            AccessTokenInfo token;
            // Note: Sign up at http://www.projectoxford.ai for the client credentials.
            Authentication auth = new Authentication("Your ClientId goes here", "Your Client Secret goes here");
            ... 
            token = auth.GetAccessToken();
            ...
            
            string requestUri = "https://speech.platform.bing.com/synthesize";
            var cortana = new Synthesize(new Synthesize.InputOptions()
            {
                RequestUri = new Uri(requestUri),
                // Text to be spoken.
                Text = "Hi, how are you doing?",
                VoiceType = Gender.Female,
                // Refer to the documentation for complete list of supported locales.
                Locale = "en-US",
                // You can also customize the output voice. Refer to the documentation to view the different
                // voices that the TTS service can output.
                VoiceName = "Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)",
                // Service can return audio in different output format. 
                OutputFormat = AudioOutputFormat.Riff16Khz16BitMonoPcm,
                AuthorizationToken = "Bearer " + token.access_token,
            });
            cortana.OnAudioAvailable += PlayAudio;
            cortana.OnError += ErrorHandler;
            cortana.Speak(CancellationToken.None).Wait();

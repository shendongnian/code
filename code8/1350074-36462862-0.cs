        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.StartsWith("google "))
            {
                System.Diagnostics.Process.Start(
                    "https://www.google.com/search?q=" + e.Result.Text.Substring(7) //"google " is 7 characters long.
                );
            } 
            ...
        }

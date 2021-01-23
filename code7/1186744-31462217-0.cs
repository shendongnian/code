    string QuoteMessageBody (MimeMessage message)
    {
        using (var quoted = new StringWriter ()) {
            quoted.WriteLine ("On {0}, {1} wrote:", message.Date.ToString ("f"), message.From.ToString ());
            using (var reader = new StringReader (message.TextBody)) {
                string line;
        
                while ((line = reader.ReadLine ()) != null) {
                    quoted.Write ("> ");
                    quoted.WriteLine (line);
                }
            }
    
            return quoted.ToString ();
        }
    }

            var encoding = System.Text.UTF8Encoding.UTF8; // this doesn't have to be set to a variable, I'm just doing it to emphasize it.
            string myText = "My Text To Assert";
            string lookupText = "This the place to write your sentence";
            string filePath = "C:\test.txt";
            string payload = System.IO.File.ReadAllText(filePath, encoding);
            payload.Replace(lookupText, String.Format("{0}{1}", lookupText, myText));
            System.IO.File.WriteAllText(filePath, payload);

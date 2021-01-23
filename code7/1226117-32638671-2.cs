            System.Text.Encoding encoding = System.Text.UTF8Encoding.UTF8; // we don't have to declare and set a variable, I'm just doing this to emphasize the encoding class and it's usage.
            string myText = "My Text To Assert";
            string lookupText = "This the place to write your sentence";
            string filePath = "C:\test.txt";
            string payload = System.IO.File.ReadAllText(filePath, encoding);
            payload.Replace(lookupText, String.Format("{0}{1}", lookupText, myText));
            System.IO.File.WriteAllText(filePath, payload);

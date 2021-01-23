            var encoding = System.Text.ASCIIEncoding.UTF8;
            string myText = "My Test To Assert";
            string lookupText = "This the place to write your sentence";
            string filePath = "C:\test.txt";
            string payload = System.IO.File.ReadAllText(filePath, encoding);
            payload.Replace(lookupText, String.Format("{0}{1}", lookupText, myText));
            System.IO.File.WriteAllText(filePath, payload);

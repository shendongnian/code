            Dictionary<string, long> FileNameAndSizes = new Dictionary<string, long>();
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://example.com/dll_files.ini");
            TextReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
             
            var splitsByLine = content.Split('\n'); //Assuming contents has "file1.dll,17662\nfile2.dll,19019";
            foreach (var s in splitsByLine)
            {
                var nameAndSize = s.Split(',');
                FileNameAndSizes.Add(nameAndSize[0], Convert.ToInt64(nameAndSize[1]));
            }

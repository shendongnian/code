    public string AddImageStream(Stream img)
        {
            MultipartParser parser = new MultipartParser(img);
            string encodedString = "";
            if (parser.Success)
            {
                // Save the file
                encodedString = SaveFile(parser.Filename, parser.ContentType, parser.FileContents);
            }
            
            return encodedString;
        }

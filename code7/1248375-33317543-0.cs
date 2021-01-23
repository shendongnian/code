    public int w { get; set; }
        public void determineSizeOfFile()
        {
            //Not used at present. Designed to count the no. of serial no. of items in the file.
            using (var reader = new StreamReader(fileToProcess)) //Remarkable solution learnt from stack overflow.
            {
                if (reader.BaseStream.Length > 1024)
                {
                    reader.BaseStream.Seek(-60000, SeekOrigin.End);
                }
                string line;
                string lastmatch = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    string pattern = @"(?<=\s{2})\d{1,7}(?=\s{2})";
                    Match match = Regex.Match(line, pattern);
                    if (match.Success)
                    {
                        lastmatch = match.Value;
                        w = Convert.ToInt32(lastmatch);
                    }
                }
            }
        }

    class AwesomeFileWriter
    {
        private const string FileName = "C:\\crypt\\crypt.txt";
        private readonly string _text;
        
        public AwesomeFileWriter(string text)
        {
            _text = text;
        }
        
        public bool WriteToFile()
        {
            try
            {
                using (System.IO.StreamWriter WriteToFile = new System.IO.StreamWriter(FileName))
                {
                    WriteToFile.Write(_text);
                    WriteToFile.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

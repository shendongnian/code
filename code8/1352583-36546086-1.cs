        private void ReWriteFile(string _newFileName)
        {
            List<string> linetoDelete = _errorLine;
            using (StreamReader reader = new StreamReader(_fileName))
            {
                using (StreamWriter writer = new StreamWriter(_newFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(!linetoDelete.Contains(line))
                            writer.WriteLine(line);
                    }
                }
            }
        }

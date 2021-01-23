        private void ReWriteFile(string NewFileName) {
            List<String> _errorLine = new List<string>() {
                "Error Line 1", "Error Line 2"
            };
            String _fileName = "InputFile.txt";
            String _outputFile = NewFileName;
            List<string> linetoDelete = _errorLine;
            
            String[] sourceLines = File.ReadAllLines(_fileName);
            if (sourceLines.Length > 0) {
                using (StreamWriter writer = new StreamWriter(_outputFile)) {
                    foreach(String line in sourceLines) {
                        if (!_errorLine.Contains(line)) {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }

    private string GetLine(string filePath, int line)
            {
                using (var sr = new StreamReader(filePath))
                {
                    for (int i = 1; i < line; i++)
                        sr.ReadLine();
                    return sr.ReadLine();
                }
            }

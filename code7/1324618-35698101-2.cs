    private void Log(string text, bool LineBreak)
        {
            try
            {
                if (LineBreak)
                {
                    File.AppendAllText("LogFile.txt", System.Environment.NewLine + System.Environment.NewLine);
                }
                File.AppendAllText("LogFile.txt", System.Environment.NewLine + DateTime.Now + ":- " + text);
            }
            catch
            {
            }
        }

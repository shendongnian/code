        public static bool IsFileOpen(string path)
        {
            FileStream stream = null;
            try
            {
                stream = File.Open(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("being used by another process"))
                    return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

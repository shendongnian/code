    public class TemporaryFile
    {
        private string _fileName = String.Empty;
        <other stuffs...>
        ~TemporaryFile()
        {
            try
            {
                File.Delete(_fileName);
            }
            catch
            {
            }
        }
    }

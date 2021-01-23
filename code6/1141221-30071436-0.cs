    public class ZipPasswordTester
    {
        public bool CheckPassword(Ionic.Zip.ZipEntry entry, string password)
        {
            try
            {
                using (var s = new PasswordCheckStream())
                {
                    entry.ExtractWithPassword(s, password);
                }
                return true;
            }
            catch (Ionic.Zip.BadPasswordException)
            {
                return false;
            }
            catch (PasswordCheckStream.GoodPasswordException)
            {
                return true;
            }
        }
     
        private class PasswordCheckStream : System.IO.MemoryStream
        {
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new GoodPasswordException();
            }
            
            public class GoodPasswordException : System.Exception { }
        }
    }

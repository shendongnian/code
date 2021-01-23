    [ComVisible(true)]
    public class TestSecureString : IUnsecurePassword
    {
        public SecureString Password
        {
            get;
            set;
        }
    
        string IUnsecurePassword.Password
        {
            get
            {
                if (Password == null)
                    return null;
    
                IntPtr ptr = Marshal.SecureStringToBSTR(Password);
                string bstr = Marshal.PtrToStringBSTR(ptr);
                Marshal.ZeroFreeBSTR(ptr);
                return bstr;
            }
            set
            {
                if (value == null)
                {
                    Password = null;
                    return;
                }
    
                Password = new SecureString();
                foreach (char c in value)
                {
                    Password.AppendChar(c);
                }
            }
        }
    }
    
    [ComVisible(true)]
    public interface IUnsecurePassword
    {
        string Password { get; set; }
    }

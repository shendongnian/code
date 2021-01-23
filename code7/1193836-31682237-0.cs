    string codeString =
        String.Format(@"using System;
        using System.Security;
        namespace SomeProgram
        {
            class MyClass
            {
                static void Main(string[] args)
                {
                    SecureString securePass = new SecureString();
                    {0} // use it the way u like
                }
            }
        }", SecureStringToString(securePassword));

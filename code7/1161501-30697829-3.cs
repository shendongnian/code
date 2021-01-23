    public static class TestExtensionClass
    {
        public static string TestExtinsionMethod(this string password)
        {
            string encriptedPassword="";
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(password);
            foreach (byte b in ASCIIValues)
            {
                encriptedPassword += b.ToString();
            }
            return encriptedPassword;
        }
    }

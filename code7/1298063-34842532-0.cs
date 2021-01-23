    this.sp.WriteLine(StringToUCS2("Привет, привіт !@#%") + char.ConvertFromUtf32(26));
----------
    public static string StringToUCS2(string str)
            {
                UnicodeEncoding ue = new UnicodeEncoding();
                byte[] ucs2 = ue.GetBytes(str);
    
                int i = 0;
                while (i < ucs2.Length)
                {
                    byte b = ucs2[i + 1];
                    ucs2[i + 1] = ucs2[i];
                    ucs2[i] = b;
                    i += 2;
                }
                return BitConverter.ToString(ucs2).Replace("-", "");
            }

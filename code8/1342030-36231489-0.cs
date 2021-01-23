    public static string setEncrypt_Account(string sParam)
            {
                sParam = Core_App.RijndaelSimple.Encrypt(sParam, "pr@se_AccPwd", "cts@devteam", "MD5", 2, "@1B2c3D4e5F6g7H8", 256);
                return sParam;
            }
            public static string getDecrypt_Account(string sParam)
            {
                sParam = Core_App.RijndaelSimple.Decrypt(sParam, "pr@se_AccPwd", "cts@devteam", "MD5", 2, "@1B2c3D4e5F6g7H8", 256);
                return sParam;
            }

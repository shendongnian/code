       public static byte [] Protect( byte [] data )
            {
                try
                {
                    return ProtectedData.Protect( data, s_aditionalEntropy, DataProtectionScope.LocalMachine );
                } 
                catch (CryptographicException e)
                {
                    Console.WriteLine("Data was not encrypted. An error occurred.");
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        
            public static byte [] Unprotect( byte [] data )
            {
                try
                {
                    return ProtectedData.Unprotect( data, s_aditionalEntropy, DataProtectionScope.LocalMachine );
                } 
                catch (CryptographicException e)
                {
                    Console.WriteLine("Data was not decrypted. An error occurred.");
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }

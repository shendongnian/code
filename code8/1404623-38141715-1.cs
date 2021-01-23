    class Program
        {
            static void Main(string[] args)
            {
                RegistryKey soeKey = Registry.CurrentUser.OpenSubKey("Console");
    
                if (soeKey != null)
                {
                    foreach (string value in soeKey.GetValueNames())
                    {
                        //Here's where the problem lies
                        if (value.Equals("FontWeight"))
                            Console.WriteLine(value);
                            //System.Diagnostics.Debug.WriteLine(value);
                    }
                }
                Console.ReadKey();
            }
        }

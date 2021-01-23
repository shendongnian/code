        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("At least we got here");//TEST
                try
                {
                    var  installedFontCollection = new InstalledFontCollection();
                    var fontFamilies = installedFontCollection.Families;
                    var count = fontFamilies.Length;
                    for (int j = 0; j < count; ++j)
                    {
                        Console.WriteLine(fontFamilies[j].Name);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
                Console.ReadKey();
            }
        }

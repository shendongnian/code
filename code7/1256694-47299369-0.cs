    class Program
    {
        static void Main(string[] args)
        {
            var edgeFound = false;
            using (var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Packages\"))
            {
                foreach (var subkey in key.GetSubKeyNames())
                {
                    if (subkey.StartsWith("Microsoft.MicrosoftEdge_"))
                    {
                        edgeFound = true;
                        break;
                    }
                }
            }
            Console.Write(edgeFound);
        }
    }

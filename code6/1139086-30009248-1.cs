        public static void Main(string[] args)
        {
            string baseDirectory = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            string programFiles = "Program Files";
            string programFilesX86 = "Program Files (x86)";
            Console.WriteLine(Environment.Is64BitProcess ? "64-Bit Process" : "32-Bit Process");
            if (Environment.Is64BitOperatingSystem)
            {
                Console.WriteLine("64-bit operating system");
                Console.WriteLine("Program Files Directory: " + Path.Combine(baseDirectory, programFiles));
                Console.WriteLine("Program Files x86 Directory: " + Path.Combine(baseDirectory, programFilesX86));
            }
            else
            {
                Console.WriteLine("32-bit operating system");
                Console.WriteLine("Program Files Directory: " + Path.Combine(baseDirectory, programFiles));
            }
            
            Console.ReadKey(true);
        }

    static void Main(string[] args)
        {
    
            string parameter = "te"; // Replace with your parameter
            
            string regexp = string.Format(@"{0}.*\.png", parameter); // Change the image format as required. eg. .png to .jpg
            DirectoryInfo di = new DirectoryInfo(@"C:\FilePath");
            foreach (var fname in di.GetFiles())
            {
                
                if (Regex.IsMatch(fname.Name, regexp) )
                {
                    Console.WriteLine(fname.Name);
                    // Do your processing here with the file.
                }
            }
            Console.ReadLine();
        }

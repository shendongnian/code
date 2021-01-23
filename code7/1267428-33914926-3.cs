        [STAThread]
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\st4r8_000\Desktop\office work\checks documents\error log check.txt");
            StringBuilder clipBuffer = new StringBuilder();
            foreach (String line in lines)
            {
                Console.WriteLine(line);
                if (clipBuffer.Length > 0)
                    clipBuffer.Append('\n');
                clipBuffer.Append(line);
                Clipboard.SetText(line);
                // Incremental addition; 
                // Clipboard.SetText(line); 
                // if new line should superecede the old one
                //Clipboard.SetText(clipBuffer.ToString());
                Console.ReadLine();
            }
            // Suspend the screen.
            Console.ReadLine();
        }
    }

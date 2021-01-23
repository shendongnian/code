        public static void Main(string[] args)
        {
            bool isLocked = IsFileLocked();
            Console.WriteLine("IsLocked = " + isLocked);
            ShowOutlookWindow();
        }
        private static bool IsFileLocked()
        {
            try
            {
                using (FileStream fs = File.Open(@"C:\path\to\non_existant_file.docx", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    fs.ReadByte();
                    return false;
                }
            }
            catch (IOException ex)
            {
                int errorCode = Marshal.GetHRForException(ex) & 0xFFFF;
                return errorCode == 32 || errorCode == 33; // lock or sharing violation
            }
        }
        private static void ShowOutlookWindow()
        {
            try
            {
                Application outlook = (Application)Marshal.GetActiveObject("Outlook.Application"); 
                // ^^ causes COMException because Outlook is not running
                MailItem mailItem = outlook.CreateItem(OlItemType.olMailItem);
                mailItem.Display();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    class Program {
        [System.STAThread]
        static void Main(string[] args) {
            byte[] cursorBytes = new System.Net.WebClient().DownloadData(@"https://github.com/tlorach/nvGraphy/raw/master/cursor1.cur");
            System.IO.Stream cursorStream = new System.IO.MemoryStream(cursorBytes, false);
            System.Windows.Forms.Cursor cursor = new System.Windows.Forms.Cursor(cursorStream);
            System.Windows.Forms.Form mainForm = new System.Windows.Forms.Form();
            mainForm.Cursor = cursor;
            System.Windows.Forms.Application.Run(mainForm);
        }
    }

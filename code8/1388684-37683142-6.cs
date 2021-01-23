    using System;
    using System.Windows.Forms;
    
    public class App
    {
        [STAThread]
        public static void Main()
        {
            string fname = AskForFile();
            if (fname == null)
                return;
            LongRunningProcess(fname);
        }
        private static string AskForFile()
        {
            string fileName = null;
            var form = new Form() { Visible = false };
            form.Load += (o, e) => { 
                using (var dlg = new OpenFileDialog())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                        fileName = dlg.FileName;
                }
                ((Form)o).Close();
            };
            
            Application.Run(form);
            return fileName;
        }
    }

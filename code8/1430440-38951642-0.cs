    public class YourClass {
        public string AppFile {get;set;}
    
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Carlos Miguel Salamat","Windows App Installer");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Choose Package File";
            file.InitialDirectory = @"c:\";
            file.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName;
                this.AppFile = file.FileName;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = "powershell.exe add-appxpackage";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText, this.AppFile);
         }

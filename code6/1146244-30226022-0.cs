    public partial class Form1 : Form
    { 
        // Class level fields
        private string fileName = String.Empty;
        private string[] fileLines;
        private int currentLine = 0;
        const char DELIM = '|';
        public void ScrubData()
        {           
    
            // Display an OpenFile Dialog box for user
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt Files|*.txt";
            openFileDialog1.Title = "Select a txt File";
            // Show the Dialog. If user clicked OK in the dialog
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog1.FileName;
                    newFileName = System.IO.Path.GetFileNameWithoutExtension(fileName) + "_scrubbed.txt";
                    fileLines = File.ReadAllLines(fileName);
                    currentLine = 0;
                } 
            }
        }
        public void BtnNext_Click(object sender, EventArgs e)
        {
    
            if (currentLine <= fileLines.Length)
            {
                string line2 = fileLines[currentLine];
                string[] word = line2.Split(DELIM);
                Txt2NormAccNum.Text = word[3];
                Txt3NormAmnt.Text = word[4];
                Txt4NormFirstNam.Text = word[1];
                Txt5NormLastNam.Text = word[2];
                Txt6NormSS.Text = word[0];
                Txt7NormItem.Text = word[5];
                currentLine = currentLine + 1;
            }
        }
    }

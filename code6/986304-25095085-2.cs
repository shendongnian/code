    namespace test
    {
        public partial class Form1 : Form
        {
            private string fileName;
            public Form1()
            {
                InitializeComponent();
            }
            private void ReplaceLineInFile(int lineNumber, string newLine)
            {
                if (File.Exists(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName);
                    lines[lineNumber] = newLine;
                    File.WriteAllLines(fileName, lines);
                }
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void LoadFile()
            {
                string[] lines = File.ReadAllLines(fileName);
                // Clear the existing rows
                tableLayoutPanel1.RowStyles.Clear();
                for (int i = 0; i < lines.Length; i++)
                {
                    // Add a new row
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    // Create the TextBox
                    TextBox txt = new TextBox();
                    // Add any initializations for the text box here
                    txt.Text = lines[i];
                    // Create the button
                    Button btn = new Button();
                    // Add any initializations for the button here
                    btn.Text = i.ToString();
                    // Handle the button's click event
                    btn.Click += btn_Click;
                    // This value helps the button know where it is and which TextBox it is associated to
                    btn.Tag = new object[] { i, txt };
                    btn.Width = 30;
                    // Add the controls to the created row
                    tableLayoutPanel1.Controls.Add(txt, 0, i);
                    tableLayoutPanel1.Controls.Add(btn, 1, i);
                }
            }
            void btn_Click(object sender, EventArgs e)
            {
                object[] btnData = (object[])((Control)sender).Tag;
                // The values are inside the sender's Tag property
                ReplaceLineInFile((int)btnData[0], ((TextBox)btnData[1]).Text);
            }
            private void button_Click(object sender, EventArgs e) // save all
            {
                List<string> lines = new List<string>();
                for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                {
                    lines.Add(((TextBox)tableLayoutPanel1.Controls[i * 2]).Text);
                }
                File.WriteAllLines(fileName, lines.ToArray());
            }
            private void button5_Click(object sender, EventArgs e) // get file
            {
                fileName = getFile.Text;
                if (File.Exists(fileName))
                {
                    //shows message if testFile exist 
                    MessageBox.Show("File " + fileName + " Exist ");
                }
                else
                {
                    //create the file testFile.txt 
                    File.Create(fileName);
                    MessageBox.Show("File " + fileName + " created ");
                }
                LoadFile();
            }
        }
    }

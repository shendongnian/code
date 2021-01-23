    public partial class SaveReadForm: Form
        {
            private OpenFileDialog opnFileDialog = new OpenFileDialog();
            Person p = new Person();
            public SaveReadForm()
            {
                InitializeComponent();
    
                opnFileDialog.Filter = "Text File[.txt]|*.txt";
    
            }
    
            private void saveBtn_Click(object sender, EventArgs e)
            {
                if (opnFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    if (!String.IsNullOrEmpty(input.Text))
                    {
                        p.Name = input.Text;
                        SaveToFile.Save(opnFileDialog.FileName, p.Name);
                    }
                    else
                    {
                        MessageBox.Show("Add your name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
    
            private void readBtn_Click(object sender, EventArgs e)
            {
                
                if (opnFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    nameLstBox.Items.Clear();
                    foreach (string s in SaveToFile.Read(opnFileDialog.FileName))
                    {
                        nameLstBox.Items.Add(s);
                    }
                }
            }

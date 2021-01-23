    private void button1_Click(object sender, EventArgs e)
        {
            Stream file;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((file = openFileDialog.OpenFile()) != null)
                {
                    
                    string fileName = openFileDialog.FileName;
                    string fileText = File.ReadAllText(fileName);
                    string[] newText = fileText.Split('Q');
                    st1name.Text = newText[0];
                    st1email.Text = newText[1];
                    st2name.Text = newText[2];
                    st2email.Text = newText[3];
                }
            }
        }

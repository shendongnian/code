        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = Path.GetFileName(openFD.FileName);
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter str = new StreamWriter(fs))
                        {
                            textpathTB.Text = path;
                            str.Write("Hello!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The path was not correct! Original error:" + ex.Message);
                }
            }
        }

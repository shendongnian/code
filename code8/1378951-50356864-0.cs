    private void button_Load_Int_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            progressBar.Value = 0;
            using (StreamReader sr = new StreamReader(pathInt))
            {
                Stream baseStream = sr.BaseStream;
                long length = baseStream.Length;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string strCode = line.Substring(4, 4);
    
                    if (listBoxCodes.FindStringExact(strCode) == -1)
                        listBoxCodes.Items.Add(strCode);
                    else
                        listBoxDuplicates.Items.Add(strCode)
                    progressBar.Value = Convert.ToInt32((double)baseStream.Position / length * 100);
                    Application.DoEvents();
                }
            }
        }

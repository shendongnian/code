    private void button2_Click(object sender, EventArgs e)
    {
        listBoxCodes.Items.Clear();
        listBoxDuplicates.Items.Clear();
        Cursor.Current = Cursors.WaitCursor;
        Application.DoEvents();
        progressBar.Value = 0;
        using (var reader = new StreamReader(textBoxGENIO.Text))
        {
            // progressBar is set for 5 unit intervals (from 0 to 100)
            // How can I show % complete reading the file?
            Stream baseStream = reader.BaseStream;
            long length = baseStream.Length;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if(line.Length > 8 && line.Substring(0, 4) == "080,")
                {
                    string strCode = line.Substring(4, 4);
                    if (listBoxCodes.FindStringExact(strCode) == -1)
                        listBoxCodes.Items.Add(strCode);
                    else
                        listBoxDuplicates.Items.Add(strCode);
                }
                progressBar.Value = baseStream.Position / length * 100;
                // Add code to update your progress bar UI
            }
        }
        Cursor.Current = Cursors.Default;
    }

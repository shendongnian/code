        void testSave()
        {
            fileName = curMonth.Text + curYear.Text + ".csv";
            if (!File.Exists(path+fileName))
            {
                try
                {
                    File.Create(path + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            try
            {
               lines = curDate.Text + "," + myDesc.Text + "," + myAmount.Text;
                File.AppendAllText(path + fileName, lines + Environment.NewLine);
                TextWriter tw = new StreamWriter(path + fileName, true);
                tw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

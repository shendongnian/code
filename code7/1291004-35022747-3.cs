        private void button19_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\foo\dgvTextFile.txt");//select name for created text file
            try
            {
                string myTableLine = ""; //variable to hold each line
                
                for (int r = 0; r <= dataGridView1.Rows.Count - 1; r++)//loop through table rows, one at a time
                {
                    //now loop though each column for the row number we get from main loop
                    for (int c = 0; c <= dataGridView1.Columns.Count - 1; c++)
                    {
                        myTableLine = myTableLine + dataGridView1.Rows[r].Cells[c].Value;
                        if (c != dataGridView1.Columns.Count - 1)
                        {
                            //set a delimiter by changinig the value between the ""
                            myTableLine = myTableLine + ",";
                        }
                    }
                    //write each line
                    file.WriteLine(myTableLine);
                    myTableLine = "";
                }
                file.Close();
                System.Windows.Forms.MessageBox.Show("Grid Export Complete.All changes saved. Use create to create commands", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (System.Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                file.Close();
            }
        }

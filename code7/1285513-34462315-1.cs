    private void ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // your code
        try
        {
            // your code
            this.Close();
        }
        catch
        {
            DialogResult dialogResult = MessageBox.Show("There was a problem loading your favorites to the database. Do you still wish to quit? \n (All changes to the favorites list will be lost)", "", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                //Cancel the formclosing event here!
                e.Cancel = true;
            }
        }
        finally
        {
            conn.Close();
        }
    }

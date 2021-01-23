    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
            using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
            {
                accountText.Text = reader.ReadLine();
                   while(!reader.EndOfStream)
                   {
                       var myString = reader.ReadLine();
                       var subitems = myString.Split("\t");
                       // Create ListItem and assign subItems here...
                   }
               }
            }
        }
    }

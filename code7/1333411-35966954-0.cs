    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
        MessageBox.Show("You clicked the save button");
        using (StreamWriter outputfile = File.CreateText("organisms.txt")) 
        {
            for (int b = 0; b < listBox1.Items.Count; b++)
            {
                outputfile.WriteLine(listBox1.Items[b].ToString());
            }
        }
    }
    else
    {
        MessageBox.Show("You hit the cancel button");
    }

    if (sfd.ShowDialog() == DialogResult.OK) {
        cp = sfd.FileName;
        //File.Create(cp); //remove this
        File.WriteAllLines(@cp, StudentTextBox.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
    }
 

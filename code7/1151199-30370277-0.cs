    private void Form1_FormClosing (object sender, FormClosingEventArgs e) {
        DialogResult dialog = MessageBox.Show("Do you want to save your progress?", "Media Cataloguer", MessageBoxButtons.YesNoCancel);
    
        if (dialog == DialogResult.Yes) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Text files|*.txt";
            savefile.Title = "Save As";
            savefile.ShowDialog();
            System.IO.FileStream fs = (System.IO.FileStream)savefile.OpenFile();
        } else if (dialog == DialogResult.No) {
            if(MessageBox.Show("Are you sure?", "Media Cataloguer", MessageBoxButtons.YesNo) == DialogResult.No){
               e.Cancel = true;
            }
        } else if (dialog == DialogResult.Cancel) {
            e.Cancel = true;
        }
    }

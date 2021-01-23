    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel=true ;
                }
         }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    { 
        const string closemsg = "Do you really want to close the program?";
        const string exit = "Exit";
        DialogResult dialog = MessageBox.Show(closemsg, exit, MessageBoxButtons.YesNo);
        if (dialog == DialogResult.Yes)
        {
            //Remove Application.Exit();
            //Application.Exit();
        }
        else if (dialog == DialogResult.No)
        {
            e.Cancel = true;
        }
    }

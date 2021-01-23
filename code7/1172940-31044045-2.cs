    private void Form1_FormClosing(object sender, FormClosingEventArgs e){
        DialogResult DialogResult = MessageBox.Show("Do you really want to exit?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (DialogResult == DialogResult.Yes)
                Application.Exit();//Here is the code to close everything
            else
                //Do stuff
}

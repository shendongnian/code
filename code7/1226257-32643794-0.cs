    private void CheckScoreButton_Click(object sender, EventArgs e)
    {
       if ( MessageBox.Show("Win: " + wins + "\nLose: " + loses + "\n\nDo you want to Continue?", "Continue?",
    MessageBoxButtons.YesNo) == DialogResult.No)
       {
          Form.Close();
       }
       else
       { 
          // Reset as necessary
       }
    }

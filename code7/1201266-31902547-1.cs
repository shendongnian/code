     private void checkBox_CheckedChanged(object sender, EventArgs e)
     {
         if(checkBox.Checked)
         {
             checkBox.Text = "Stop";
             sound.Play();
         }
         else
         {
             checkBox.Text = "Play";
             sound.Stop();
         }
    }

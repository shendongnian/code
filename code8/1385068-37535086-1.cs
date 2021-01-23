    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
         // To know if your event is working and the value of the key who's pressed
         MessageBox.Show("Key Pressed = "
                       + e.KeyCode.ToString()
                       + ", Value = "
                       + e.KeyValue.ToString());
         // Example - add some actions bellow
         if (e.KeyValue == 13)
             MessageBox.Show("Return Key Pressed");
    }

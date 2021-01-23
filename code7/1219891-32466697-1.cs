    private void Timer_Tick( object sender, EventArgs e )
        {
            if ( lines.Count > 0 )
            {
                richTextBox1.Text += Environment.NewLine + "Copying: " + lines.Dequeue();
                counter++;
            }
        }

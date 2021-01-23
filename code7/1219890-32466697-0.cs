    private void Timer_Tick( object sender, EventArgs e )
        {
            richTextBox1.Text += Environment.NewLine + "Copying: " + lines.Dequeue();
            counter++;
        }

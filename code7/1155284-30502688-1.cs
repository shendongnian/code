    private void start_Click(object sender, EventArgs e)
    {
        boolValue = true;
        while (boolValue)
        {
            counter++; //Class Variable =0 by default
            Thread.Sleep(1000);
            lbl.Text = counter.ToString();
                        
            if (counter == int.MaxValue)
            {
               boolValue = false;
            }
        }
    }

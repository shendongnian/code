    private async void button1_Click(object sender, EventArgs e)
    {
        if (globalVars.spacerunning)
        {
            globalVars.spacerunning = false;
        }
        else
        {
            globalVars.spacerunning = true;
            
            while (globalVars.spacerunning)
            {
                await Task.Delay(1000);
                SendKeys.Send(" ");
            }
        }
    }

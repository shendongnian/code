    private async void button1_Click(object sender, EventArgs e)
    {
        globalVars.spacerunning = !globalVars.spacerunning;
            
        while (globalVars.spacerunning)
        {
            await Task.Delay(1000);
            SendKeys.Send(" ");
        }
    }

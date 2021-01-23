    private async Task DoIt()
    {
        for(int i = 0 ; i < numExpositions; i++)
        {
            wordLabel.Visible = true;
            await Task.Delay(expositionTime); //expositionTime is the number of milliseconds to keep the label visible
            wordLabel.Visible = false;
            await Task.Delay(intervalTime); //intervalTime is the number of milliseconds to keep the label hidden
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        DoIt();
    }

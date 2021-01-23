    private async Task DoIt()
    {
        for(int i = 0 ; i < numExpositions; i++)
        {
            wordLabel.Visible = true;
            await Task.Delay(expositionTime);
            wordLabel.Visible = false;
            await Task.Delay(intervalTime);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        DoIt();
    }

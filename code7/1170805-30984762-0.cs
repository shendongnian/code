    private bool btnClicked = false;
    public void btnChallenge_Click(object sender, EventArgs e)
    {
         btnClicked = true;
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(btnClicked)
        {
            e.Cancel=true;
        }
    }

    bool bStartSomething = false; // Your condition flag
    private void button1_Click(object sender, EventArgs e)
    {
        if (bStartSomething == true)
        {
            Process.Start("Something.exe");
        }
        else
        {
            Process.Start("Somethingelse.exe");
        }
        this.Close(); // Close GUI
    }

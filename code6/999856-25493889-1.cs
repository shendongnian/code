    private async void myForm_Load(object s, EventArgs e)
    {
        await CheckForUpdate();
        loadFinished = true;
        if (this.needsUpdate == true)
        {
            Console.WriteLine("Needs update...");
        }
        else
        {
            Console.WriteLine("update is false");
        }
    }

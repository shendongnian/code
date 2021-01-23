    public async bool PopulateTV()
    {
        using (var waitingForm = new WaitingForm())
        {
            waitingForm.Show();
            return await Task.Run(() => DoHeavyWork());
        }
    }

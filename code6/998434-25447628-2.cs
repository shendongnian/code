    public void UpdateWorkerLifeBit(bool workerLifeBit)
    {
        if (this.checkBox.InvokeRequired)
        {
            this.Invoke(new Action(() => checkBox.Checked = workerLifeBit));
        }
        else
        {
            checkBox.Checked = workerLifeBit;
        }
    }

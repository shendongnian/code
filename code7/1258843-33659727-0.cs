    private void WriteProgressMessage(string message)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(() => this.WriteProgressMessage(message)));
        }
        else
        {
            this.ProgressList.Items.Add(message);
            this.ProgressList.SelectedIndex = this.ProgressList.Items.Count - 1;
            this.ProgressList.SelectedIndex = -1;
        }
    }

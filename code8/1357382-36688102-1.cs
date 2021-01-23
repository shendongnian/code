    private void Btn1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            CheckForIllegalCrossThreadCalls = false; 
            _myViewModel.Name = "Updating from worker thread!"; It causes cross thread issue
            CheckForIllegalCrossThreadCalls = true;
        });
    }

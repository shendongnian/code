    private void Btn1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            _myViewModel.Invoke((MethodInvoker)(() => _myViewModel.Name = "Updating from worker thread!"; ));
        });
    }

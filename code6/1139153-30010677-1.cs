    //I'm assuming this is an event handler.
    private async void SomeEventHandler(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lvwCustomers.Items)
        {
            await customerPresenter.ProcessCustomer(item.Tag as Customer);
        }
    }

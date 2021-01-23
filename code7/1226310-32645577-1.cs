    protected void btnAsyncPostBack_Click(object sender, EventArgs e) {
        RegisterAsyncTask(new PageAsyncTask(MyMethodAsync));
    }
    
    private async Task MyMethodAsync(object sender, EventArgs e, CancellationToken cancellationToken) {
        var sum = await GetSumAsync();
        lblMessage.Text = string.Format("Sum = {0}", sum);
    }

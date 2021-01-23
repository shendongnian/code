    private void OnDeleteCommandExecuted()
    {
        if (this.Products.IsAddingNew)
        {
            this.Products.CancelNew();
            this.Products.AddNew();
        }
    }

    private void firstPhaseBtn_Click(object sender, EventArgs e)
    {
    	string orderNumber = string.Empty;
    
    	labelLoading.Text = "Creando orden...";
    	labelLoading.Visible = true;
    
    	Models.FirstPhaseModel model = new Models.FirstPhaseModel()
    	{
    		// Data...
    	};
    
    	var task = Task.Factory.StartNew(() =>
    	{
    		if (_viewModel == null)
    			_viewModel = new MainViewModel();
    
    		orderNumber = _viewModel.FirstPhase(model);
    	})
    	.ContinueWith(result =>
    	{
    		if (result.IsFaulted)
    		{
    			labelLoading.Visible = false;
    			labelLoading.Text = string.Empty;
    			MessageBox.Show(this, _viewModel.ClientCustomError, "Error");
    		}
    		else
    		{
    			orderNumberLabel.Text = orderNumber;
    
    			firstPhaseBtn.Enabled = false;
    			labelLoading.Visible = false;
    			labelLoading.Text = string.Empty;
    		}
    	});
    }

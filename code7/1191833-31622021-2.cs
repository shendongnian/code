    private void ClearOilLube()
    {
        oilChangeCheckBox.Checked = false;
        lubeJobCheckBox.Checked = false;
    }
    
    private void ClearFlushes()
    {
        radiatorFlushCheckBox.Checked = false; 
        transFlushCheckBox.Checked = false;
    }
    
    private void ClearMisc()
    {
        inspectionCheckBox.Checked = false;
        replaceMufflerCheckBox.Checked = false;
        tireRotationCheckBox.Checked = false;
    }
    
    private void ClearOther()
    {
        partsCostInputTextBox.Text = "";
        laborInputTextBox.Text = "";
    }
    
    private void ClearFees()
    {
        servicesLaborDispLabel.Text = "";
        partsDispLabel.Text = "";
        partsTaxDispLabel.Text = "";
        totalFeesDispLabel.Text = "";
    }

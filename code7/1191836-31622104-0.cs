        private void ClearOilLube ()
        {
            oilChangeCheckBox.Checked = false;
            lubeJobCheckBox.Checked = false;
        }
    
        private void ClearFlushes ()
        {
            radiatorFlushCheckBox.Checked = false; 
            transFlushCheckBox.Checked = false;
        }
    
        private void ClearMisc ()
        {
            inspectionCheckBox.Checked = false;
            replaceMufflerCheckBox.Checked = false;
            tireRotationCheckBox.Checked = false;
        }
    
        private void ClearOther ()
        {
            partsCostInputTextBox.Text = null;
            laborInputTextBox.Text = null;
        }
    
        private void ClearFees ()
        {
            servicesLaborDispLabel.Text = null;
            partsDispLabel.Text = null;
            partsTaxDispLabel.Text = null;
            totalFeesDispLabel.Text = null;
        }

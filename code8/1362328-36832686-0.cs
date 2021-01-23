    private void btnSave_Clicked()
	    {
	        if (!IsValidDataEntered()) return;
	        Save();
	    }
        private bool IsValidDataEntered()
	    {
	        if (!(this.RoundTrip.Checked || this.OneWay.Checked))
	            MessageBox.Show("Select an option for Trip Type");
            else if (!(this.NorthRad.Checked || this.ExpressRad.Checked || this.ExpressRad.Checked))
                MessageBox.Show("Select an Option for Route Type");
            else if (!(this.YesNeeded.Checked || this.NotNeeded.Checked))
                MessageBox.Show("Select an option for accessibility");
            else if (this.AdultNum.Value == 0 && this.SeniorNum.Value == 0 &&
                     this.ChildNum.Value == 0)
                MessageBox.Show("Select at least one ticket");
            else
                return true;
            return false;
	    }

        private void dtpTime_ValueChanged(object sender, EventArgs 
        {
            dtpDate.Value = dtpDate.Value.Date + dtpTime.Value.TimeOfDay
        }
        private void dtpDate_ValueChanged(object sender, EventArgs 
        {
            dtpTime.Value = dtpDate.Value.Date + dtpTime.Value.TimeOfDay
        }

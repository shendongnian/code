        private void ViewReportButton_Click(object sender, EventArgs e)
        {
            string selIndex2 = AvailableReportsDropDownBox.SelectedItem.ToString();
            tabControl.SelectedTab = tabInspReport;
            populateViewReportTabOutputControls(selIndex2);
            activateViewReportTabOutputControls();
        }

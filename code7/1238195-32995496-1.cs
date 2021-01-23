        using OutlookTools = Microsoft.Office.Tools.Outlook;
        using Outlook = Microsoft.Office.Interop.Outlook;
        //....class definition, etc
        private void CustomFormRegion_FormRegionShowing(object sender, System.EventArgs e) {
            OutlookTools.FormRegionControl control = (OutlookTools.FormRegionControl)sender;
            Outlook.AppointmentItem item = (Outlook.AppointmentItem)control.OutlookItem;
        }
    

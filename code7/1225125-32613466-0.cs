     private void InspectorsOnNewInspector(Outlook.Inspector inspector)
        {
            MessageBox.Show("ola");
            if (!(inspector.CurrentItem is Outlook.TaskItem)) return;
            var taskItem = (Outlook.TaskItem) inspector.CurrentItem;
            taskItem.Open += (ref bool cancel) =>
            {
                try
                {
                    inspector.SetCurrentFormPage("OutlookAddIn.RequestFormRegion");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            };
        }

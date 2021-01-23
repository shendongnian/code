     public String SelectedTitle
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                    if (SelectedItem.isTest1)
                        builder.Append("Browse subfolders, ");
                    if (SelectedItem.isTest2)
                        builder.Append("Enter filename at the panel, ");
                    if (SelectedItem.isTest3)
                        builder.Append("Always show scan settings, ");
                    if (builder.Length == 0)
                        builder.Append("None");
                
                return builder.ToString().Trim().TrimEnd(',');
            }
        }
    private void SelectedItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateProperty("SelectedTitle");
        }

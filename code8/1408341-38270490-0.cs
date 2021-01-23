    public DriveComboBox()
        : base()
    {
        if (IsInDesignMode == false)
        {
            foreach (ImageComboBoxItem item in allImageComboBoxItems)
            {
               this.Items.Add(item);                
            }
        }
    }  

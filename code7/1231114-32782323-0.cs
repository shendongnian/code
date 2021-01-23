    class YourClass
    {
        DataRepeaterItem DataRepeater1_PreviousItem { get; set; }
    
        // ... some other code
        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {
            if (DataRepeater1_PreviousItem != null)
                DataRepeater1_PreviousItem.BackColor = Color.White;
        
            dataRepeater1.CurrentItem.BackColor = Color.Red;
        
            DataRepeater1_PreviousItem = dataRepeater1.CurrentItem;
        }
    }

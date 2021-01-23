        public string ItemDescription { get; }
    
        public UserControl CustomUserControlForViewItem { get; }
    
        public PageViewItemModel()
        {
            // Initialize the associated custom user control here
            CustomUserControlForViewItem = new YourCustomUserControlClass();
    
            // Set the display name for the list view
            ItemDescription = MyListViewItemName;
        }
    }

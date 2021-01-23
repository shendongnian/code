       {
          CheckedCommand = new RelayCommand(() => this.CheckAllCheckboxes());           
        }
    
        public RelayCommand CheckedCommand { get; set; }
    
        public void CheckAllCheckboxes()
        {
            //set IsSelected true for all items here
        }

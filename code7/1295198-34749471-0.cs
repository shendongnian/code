    private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                Set(ref isSelected, value);
    			
    			if(isSelected)
    			{
                    if(!SelectedVNodes.Any(v => v.Name == this.Name))
    				SelectedVNodes.Add(this);
    			}
    			else{
    			    if(SelectedVNodes.Any(v => v.Name == this.Name))
    			    SelectedVNodes.Remove(this);
    			}
                Console.WriteLine("selected/deselected");
            }
        }

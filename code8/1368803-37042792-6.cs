     private class BranchItem
        {
           // I Take this class variable to take the Selected value from combo box control
            public int ID; 
            public string Name;
            public BranchItem(int BranchID, string BranchName) //This is construct that initiate the Class 
            {
                ID = BranchID;
                Name = BranchName;
            }
            public override string ToString()
            {
                return Name; //this for text that appear in Combo Box control
            }
        }

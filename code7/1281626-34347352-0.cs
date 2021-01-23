    public partial class CarColor
    {  
        publlic string LocalizedName
        {
            get
            {
                return GetLocalizedName(this.Name);
            }
        }
    
        private string GetLocalizedName(string name)
        {
            // put the logic for localizing the name here
        }
    }

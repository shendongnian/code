    public partial class Category
    {
        public string CleanDetails
       { 
            get{ return StripHtml(this.Details ); } 
       } 
    }

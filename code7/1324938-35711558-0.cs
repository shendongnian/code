    public DateTime DetailsDate
    {
         get{
             if(ViewState["DetailsDate"] == null)
             {
                  return DateTime.Today;
             }
             else
             {
                  return (DateTime)ViewState["DetailsDate"];
             }
         }
         set {ViewState["DetailsDate"] = value;}
    }

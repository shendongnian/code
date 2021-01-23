    public partial class YourDataContext
    {        
        partial void UpdateTag(Tag instance)
        {
            //If PostID is null
            if(!instance.PostID.HasValue)
            {
                //Delete this record from the DB
                this.ExecuteDynamicDelete(instance);
            }
        }
    }

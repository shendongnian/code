    public partial class MyDataContext 
    {
        partial void OnCreated()
        {
            var options = new DataLoadOptions();
            options.LoadWith<Vote>(v => v.Post);
            options.LoadWith<Vote>(v => v.Userprofile);
            LoadOptions = options;                    
        }
    }

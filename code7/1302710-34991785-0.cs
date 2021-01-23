    [CustomCategoryID] 
    public partial class CMSModuleLoader 
    { 
    private class CustomCategoryID : CMSLoaderAttribute 
    { 
        public override void Init() 
        { 
            CategoryInfo.TYPEINFO.Events.Insert.After += Insert_After; 
        } 
        void Insert_After(object sender, CMS.DataEngine.ObjectEventArgs e) 
        { 
            var category = e.Object as CategoryInfo; 
            if (category != null) 
            { 
                category.CategoryID = 999, // manually set
                category.Update(); 
            } 
        } 
    } 
    } 

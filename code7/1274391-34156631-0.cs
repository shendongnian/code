    public class FileFolderDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FileTemplate { get; set; }
        public DataTemplate FolderTemplate { get; set; }        
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var viewModelPublic = item as OneDrivePublicFile;
            if (viewModelPublic != null)
            {
                if (viewModelPublic.IsFile())
                {
                    return FileTemplate;
                }
                return FolderTemplate;
            }          
            return FolderTemplate;
           
        }
    }

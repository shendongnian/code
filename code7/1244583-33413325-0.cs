            string lastSavedBy = null;
            using (var so = ShellObject.FromParsingName(file))
            {
                var lastAuthorProperty =     so.Properties.GetProperty(SystemProperties.System.Document.LastAuthor);
                if (lastAuthorProperty != null)
                {
                    var lastAuthor = lastAuthorProperty.ValueAsObject;
                    if (lastAuthor != null)
                    {
                        lastSavedBy = lastAuthor.ToString();
                    }
                }
            }
   
 

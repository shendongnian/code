    public class NewVariablesReplacer : MasterVariablesReplacer
    {
        public override string Replace(string text, Item targetItem)
        {
            //still need to assert these here
            Sitecore.Diagnostics.Assert.ArgumentNotNull(text, "text");
            Sitecore.Diagnostics.Assert.ArgumentNotNull(targetItem, "targetItem");
            string tempTxt = text;
            if (text.Contains("$path"))
            {
                Sitecore.Diagnostics.Assert.ArgumentNotNull(targetItem.Paths, "targetItem.Paths");
                Sitecore.Diagnostics.Assert.ArgumentNotNull(targetItem.Paths.FullPath, "targetItem.Paths.FullPath");
                tempTxt = text.Replace("$path", targetItem.Paths.FullPath);
            }
            
            //Do what you would normally do.
            return base.Replace(tempTxt, targetItem);
        }
    }

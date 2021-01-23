    [Serializable]
    public class MyBrokenLinksValidator : BrokenLinkValidator
    {
        public RedrowBrokenLinksValidator() : base()
        {
        }
        public RedrowBrokenLinksValidator(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
        protected override ValidatorResult Evaluate()
        {
            ValidatorResult returnVal = base.Evaluate();
            if (returnVal != ValidatorResult.Valid)
            {
                Item obj = base.GetItem();
                ItemLink[] brokenLinks = obj.Links.GetBrokenLinks(false);
                //are all the broken links basically because they are contextual?
                if (brokenLinks.All(a => a.TargetPath.Contains("$development")))
                {
                    foreach (ItemLink brokenLink in brokenLinks)
                    {
                        Database database = Sitecore.Configuration.Factory.GetDatabase("master");
                        //try again but replacing the varible with a context
                        var secondTryPath = brokenLink.TargetPath.Replace(
                            "$development", obj.Paths.Path);
                        Item secondTryItem = database.GetItem(secondTryPath);
                        if (secondTryItem == null)
                            return returnVal;
                    }
                    //if we've got here then all the links are valid when adding the context
                    return ValidatorResult.Valid;
                }
            }
            return returnVal;
        }
    }

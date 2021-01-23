            string TargetPage = Page.AppRelativeVirtualPath;
            if (TargetPage.ToLower().Contains("one"))
            {
                link1.Attributes.Add("style", "background: red;");
            }
            else if (TargetPage.ToLower().Contains("two"))
            {
                link2.Attributes.Add("style", "background: blue;");
            }
            else
            {
                link1.Attributes.Add("style", "background: white;");
                link2.Attributes.Add("style", "background: white;");
            }

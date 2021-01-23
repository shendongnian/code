    public HtmlEdit TbxUserName
        {
            get
            {
                if ((tbxUserName == null))
                {
                    tbxUserName = new HtmlEdit(browser);
                    tbxUserName.SearchProperties[HtmlControl.PropertyNames.Id] = "UserName";
                }
                return tbxUserName;
            }
        }

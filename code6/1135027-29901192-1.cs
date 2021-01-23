    public void Page_Load{
       Item productItem = itemHelper.GetItemByPath(currentItemPath);
       Sitecore.Data.Fields.ImageField imgField = ((Sitecore.Data.Fields.ImageField)productItem.Fields["Logo"]);
        if (imgField.Value != "")
        {
            this.imageTitle.Visible = true;
            this.textTitle.Visible = false;
        }
        else {
            this.imageTitle.Visible = false;
            this.textTitle.Visible = true;
            this.productTitleLiteral.Text = productItem["Produkt Titel"];
        }
    }

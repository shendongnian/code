    private HtmlElement FindListItem(int id)
    {
        HtmlElement listItem = this.FindControl("item" + id.ToString()) as HtmlElement;
        if (listItem != null && listItem.TagName == "li")
        {
            return listItem;
        }
        return null;
    }

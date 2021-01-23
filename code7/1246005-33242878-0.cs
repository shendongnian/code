    [Extension()]
    public List<string> SelectedValues(ListControl lst)
    {
    	List<string> returnLst = new List<string>();
    	foreach (ListItem li in lst.Items)
        {
            if (li.Selected == true)
            {
                returnLst.Add(li.Value);
            }
    	return returnLst;
    }

    private Int32 GetTableRowCount(string tableID)
    {
        Int32 count = 0;
    
        if (webBrowser1.Document != null)
        {
            HtmlElement tableElem = webBrowser1.Document.GetElementById(tableID);
            if (tableElem != null)
            {
                foreach (HtmlElement rowElem in tableElem.GetElementsByTagName("TR"))
                {
                    count++;
                }
            }
            else
            {
                throw(new ArgumentException("No TABLE with an ID of " + tableID + " exists."));
            }
        }
    
        return(count);
    }

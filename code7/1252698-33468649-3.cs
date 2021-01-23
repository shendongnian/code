    protected void DoSomethingWithValue()
        {
            Inventory MyInventoryItem = GetSelectedProduct();
            if (MyInventoryItem != null)
            {
                // selected item successfully parsed
                // do something with it.
                Response.Write(
                    string.Format("Your selected product:<br />{0}<br />UniqueID: {1}<br />Price: {2}",
                    Server.HtmlEncode(MyInventoryItem.ProductDescription),
                    MyInventoryItem.ProductID,
                    MyInventoryItem.ProductPrice.ToString("C")
                ));
            }
            else
            {
                // error parsing information stored in drop down list value
            }
        }

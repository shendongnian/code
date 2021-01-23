    public class CreateItemTemplate : ITemplate
    {
        private ListItemType listItemType;
        private string _ColumnName;
        public CreateItemTemplate() { }
        public CreateItemTemplate(ListItemType Item, string ColumnName)
        { 
            listItemType = Item;
            _ColumnName = ColumnName;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            if (listItemType == ListItemType.Item)
            {
                
                Label lblUserData = new Label();
                lblUserData.DataBinding += new EventHandler(DataFormatter);
                container.Controls.Add(lblUserData);
            }
        }
        void DataFormatter(object sender, EventArgs e)
        {
            //Here you can write logic to display data
            Label lbl = (Label)sender;
    //(Below line)Here we are getting the container, that is GridViewRow which we are binding with our item template. Since there is a data source for this gridview (you surely assigned datasource), so each row will contain 'SenderDetails' object there.
                GridViewRow container = (GridViewRow)lbl.NamingContainer; 
    //Now we are extracting particular column data from GridViewRow object, we also know its type, that is ChatUserDetails 
            var objChatUserDetails = (ChatUserDetails )DataBinder.Eval(container.DataItem, _ColumnName);
            if (objChatUserDetails != null)
            {
                lbl.Text = "UserName : " + objChatUserDetails.UserName + ", CompanyName : " + objChatUserDetails.CompanyName ;
            }
        }
    }

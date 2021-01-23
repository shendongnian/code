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
            GridViewRow container = (GridViewRow)lbl.NamingContainer;
            var objChatUserDetails = (sDetail)DataBinder.Eval(container.DataItem, _ColumnName);
            if (objChatUserDetails != null)
            {
                lbl.Text = "UserName : " + objChatUserDetails.UserName + ", CompanyName : " + objChatUserDetails.CompanyName ;
            }
        }
    }

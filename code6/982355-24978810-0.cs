    <%@ Page Language="C#" AutoEventWireup="True" %>
    
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <title>Repeater Example</title>
        <script language="C#" runat="server">
            
            public class PositionData
            {
                private int id;
                private string name;
                private string _data;
                private bool selected;
    
                public PositionData(int id, string name, string data)
                {
                    this.name = name;
                    this._data = data;
                }
    
                public int Id
                {
                    get { return id; }
                }
                
                public string Name
                {
                    get { return name; }
                }
    
                public string data
                {
                    get { return _data; }
                }
    
                public bool Selected
                {
                    get { return selected; }
                }
            }
    
    
            void Page_Load(Object Sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ArrayList values = new ArrayList();
    
                    values.Add(new PositionData(1, "Prod1", "Info1"));
                    values.Add(new PositionData(2, "Prod2", "Info1"));
                    values.Add(new PositionData(3, "Prod3", "Info1"));
    
                    Repeater1.DataSource = values;
                    Repeater1.DataBind();
                }
    
                if (IsPostBack)
                {
                    foreach (RepeaterItem i in Repeater1.Items)
                    {
                        //Retrieve the state of the CheckBox
                        CheckBox cb = (CheckBox)i.FindControl("selectUser");
                        HtmlInputHidden info = (HtmlInputHidden)i.FindControl("fieldName");
                        String itemInfo = info.Value;
                        if (cb.Checked)
                        {
                            // do whatever you want with selected item
                            // having it's ID
                        }
                    }
                }
    
            }
    
    
            private void Repeater1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var myHidden = (HtmlInputHidden)e.Item.FindControl("fieldName");
                    myHidden.Value = ((PositionData)e.Item.DataItem).Id.ToString();
                }
            }
    
        </script>
    </head>
    <body>
        <h3>
            Repeater Example</h3>
        <form id="form1" runat="server">
        <b>Repeater1:</b>
        <br />
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_OnItemDataBound">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td>
                            <b>Select this one</b>
                        </td>
                        <td>
                            <b>Name</b>
                        </td>
                        <td>
                            <b>Data</b>
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        Select
                        <asp:CheckBox ID="selectUser" runat="server" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "name") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "data") %>
                        <input id="fieldName" runat="server" type="hidden" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <button id="submitButton" runat="server">Submit!</button>
        </form>
    </body>
    </html>

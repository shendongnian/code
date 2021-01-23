    <div class="deal-info">             
         <h3>Name</h3>
         <p>Description</p>
         <p>Location</p>
         <p>Price</p>
    </div>
    <asp:PlaceHolder ID = 'yourplaceholder' runat = 'server' />
    System.Text.StringBuilder html = new System.Text.StringBuilder();
    //Any code...
    //html.Append("..")
    yourplaceholder.Controls.Add(new System.Web.UI.LiteralControl(html.ToString()));

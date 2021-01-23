    <html>
      <body>
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server" ID="ScriptManager1">
            </asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer runat="server" ID="Timer1" Interval="2000" OnTick="Timer1_Tick" />
                    <asp:Label Text="no images loaded" ID="LabelImageName" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </body>
    </html>
    <script runat="server" type="text/vb">
  
    string[] _arrImgNames = new string[] { "red", "green", "blue" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // set counter session variable only the first time the page is loaded (not when script refreshs)
            Session["counter"] = -1;
        }
    }
    private void Timer1_Tick(Object sender, EventArgs e)
    {
       
        string textToShow = String.Format(
            "Now the program shows image '{0}' "
            , this.GetNextSlideImageName());
        LabelImageName.Text = textToShow;
    }
    private string GetNextSlideImageName()
    {
        // get the counter from session variable 
        int counter = Convert.ToInt32(Session["counter"]);
        // increase the counter 
        counter++;
        if (counter >= this._arrImgNames.Length)
        {
            counter = 0;
        }
        // updating the session variable 
        Session["counter"] = counter;
        // compose the image name 
        string imageName = String.Format("{0}.png", this._arrImgNames[counter]);
        return imageName;
    }
    </script>

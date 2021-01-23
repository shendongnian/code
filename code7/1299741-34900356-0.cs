    <li role="presentation" id="liDefault" runat="server"><a href="Default.aspx">Home</a></li>
    public String linkDefault
    {
        get 
        {
            return "not_active";
        }
        set
        {
            liDefault.Attributes.Add("class", "" + value + "");
        }
    }

    <%@ Application language="C#" %>
    <script runat="server">
    public override string GetVaryByCustomString(HttpContext context, 
        string arg)
    {
        // arg is your custom 'Vary' header.
        if(arg == "minorversion")
        {
            return "Version=" +
                context.Request.Browser.MinorVersion.ToString();
        }
        return base.GetVaryByCustomString(context, arg);
    }
    </script>

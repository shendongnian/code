    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static int BindRepeater(int justparam)
    {
        int result = 0;
        Repeater.DataSource = ImageList;
        Repeater.DataBind();
        return result;
    }

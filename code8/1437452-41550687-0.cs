    protected void Page_Load(object sender, EventArgs e)
    {
       var  objDict = new Dictionary<string, object>();
        var boolDict = new Dictionary<string, bool>();
        Session["ExistingValue"] = false;
        bool? nullableValue = false;
        Session["ExistingValueNullable"] = nullableValue;
        var existingValue = (bool)Session["ExistingValue"];
        var existingValueIsNotNull = Session["existingValue"] != null;
        objDict["ExistingValue"] = false;
        boolDict["ExistingValue"] = false;
        bool existingValueIsNotNullIf = false;
        if (Session["ExistingValue"] != null)
        {
            existingValueIsNotNullIf = true;
        }
    }

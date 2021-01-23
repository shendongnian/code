    string password = GetPreviousPageControlValue("txtPassCode1");
    private string GetPreviousPageControlValue(string ctlId)
    {
        foreach (string key in Request.Form.AllKeys)
        {
            string[] tokens = key.Split('$');
            if (tokens[tokens.Length - 1] == ctlId)
            {
                return Request.Form[key];
            }
        }
        return null;
    }

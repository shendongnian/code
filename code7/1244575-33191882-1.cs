    public override String Message
    {
        get {
            String s = base.Message;
            if (!String.IsNullOrEmpty(m_paramName)) {
                String resourceString = Environment.GetResourceString("Arg_ParamName_Name", m_paramName);
                return s + Environment.NewLine + resourceString;
            }
            else
                return s;
        }
    }

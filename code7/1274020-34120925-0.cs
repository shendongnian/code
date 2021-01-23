    string s = "";
    
    public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\cassf\Documents\Tyler Tech\FL\ncc3\CM_Property.csv", true))
            {            
                foreach (PropertyInfo inputColumn in Row.GetType().GetProperties())
                {
                    if (!inputColumn.Name.EndsWith("IsNull"))
                    {
                    try
                    {
                        s += ValueToString(inputColumn.GetValue(Row,null));
                    }
                    catch
                    {
                        some code
                    }
                }
            }
        }
    }
    protected string ValueToString(object value)
    {
        if (value == null)
            throw new ArgumentNullException("I don't know how to convert null to string, implement me!");
        switch (Type.GetTypeCode(value.GetType()))
        {
            // Any kind of special treatment, you implement here...
            case TypeCode.Boolean: return Convert.ToInt16(value).ToString();
            default: return value.ToString(); // ...otherwise, just use the common conversion
        }
    }

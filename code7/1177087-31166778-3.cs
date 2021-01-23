    public static string GetMyType(this Enum eValue){
        var _nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof (MyTypeAttribute), false);
        // handle other stuff if necessary
        return ((MyTypeAttribute) _nAttributes.First()).TypeString;
    }
 

    public static void CheckElement(Element element, State state = null, int? value = null)
    {
        if ((state != null && element.State == state) || (value != null && element.Value == value.Value))
        {
            //some work
        }
    }

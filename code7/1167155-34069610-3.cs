    public static class CallbackContainer
    {
        public static Action<string> Callback 
        { 
           get
           {
             return (Action<string>)HttpContext.Current.Items["CallbackContainer.Callback"];
           }
           set
           {
             HttpContext.Current.Items["CallbackContainer.Callback"] = value;
           }
        }
    }

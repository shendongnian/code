    public sealed class ViewTagAttribute : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewType"></param>
        public ViewTagAttribute(System.Type viewType)
        {
            this.type = viewType;
        }
    
        /// <summary>
        /// Create an instance of the associated view
        /// </summary>
        /// <returns></returns>
        public static View CreateViewInstanceForEnumValue<T>(T enumValue)
        {
            var attributes = typeof(T).GetField(enumValue.ToString()).GetCustomAttributes(true);
            var viewAttr = (from a in attributes where a is ViewTagAttribute select (ViewTagAttribute)a).FirstOrDefault();
    
            if (viewAttr != null)
                return System.Activator.CreateInstance(viewAttr.type) as View;
    
            return null;
        }
    
        /// <summary>
        /// Associated view type
        /// </summary>
        private readonly System.Type type;
    }

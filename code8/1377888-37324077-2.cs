    /// <summary>
    /// helps to display value according to decorating attributes
    /// </summary>
    public class AttributeBasedObjectDataProvider : ObjectDataProvider
    {
        /// <summary>
        /// returns value of enum according its two attributes
        /// 1. DescriptionAttribute - provide a dispaly name of the enum value
        /// 2. ShouldBeHiddenAttribute - provide a dispaly state of the enum
        /// </summary>
        /// <param name="enumObj">enum field value</param>
        /// <returns>if ShouldBeHiddenAttribute.HiddenInUi value is true return null else enum Description if defined(or enum actual value id Description is not defined)</returns>
        public object GetEnumValues(Enum enumObj)
        {
            //get the ShouldBeHiddenAttribute value
            var isHidden = enumObj.GetType().GetRuntimeField(enumObj.ToString()).
                GetCustomAttributes(typeof (ShouldBeHiddenAttribute), false).
                SingleOrDefault() as ShouldBeHiddenAttribute;
            if (isHidden != null && isHidden.HiddenInUi) return null;
            //get the DescriptionAttribute value
            var attribute = enumObj.GetType().GetRuntimeField(enumObj.ToString()).
                GetCustomAttributes(typeof (DescriptionAttribute), false).
                SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? enumObj.ToString() : attribute.Description;
        }
        /// <summary>
        /// returns collection of enum values
        /// </summary>
        /// <param name="type">enum type</param>
        /// <returns>collection of enum values</returns>
        public List<object> GetShortListOfApplicationGestures(Type type)
        {
            var shortListOfApplicationGestures =
                Enum.GetValues(type).OfType<Enum>().Select(GetEnumValues).Where(o => o != null).ToList();
            return
                shortListOfApplicationGestures;
        }
    }

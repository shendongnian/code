    /// <summary>
    /// helps to hide the enum value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ShouldBeHiddenAttribute : Attribute
    {
        public ShouldBeHiddenAttribute(bool isHiddenInUi)
        {
            HiddenInUi = isHiddenInUi;
        }
        public bool HiddenInUi { get; set; }
    }

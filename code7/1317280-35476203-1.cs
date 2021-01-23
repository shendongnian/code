    public sealed class CompareCustomAttribute : System.Web.Mvc.CompareAttribute
    {
        public CompareCustomAttribute(string otherProperty)
            : base(otherProperty)
        {
        }
        public string ResourceKey { get; set; }
        public string ClassKey { get; set; }
        public override string FormatErrorMessage(string name)
        {
            return Convert.ToString(HttpContext.GetGlobalResourceObject(this.ClassKey, this.ResourceKey));
        }
    }

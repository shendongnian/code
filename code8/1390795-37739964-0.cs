    public class FieldTemplate_JSONSerialization_Switches
    {
        public static bool Fields = true;
        public static bool Formats = true;
    }
    public class Options
    {
        public List<FieldTemplate> Templates { get; set; }
    }
    public class FieldTemplate
    {
        public string Name { get; set; }
        public List<int> Fields { get; set; }
		public List<string> Formats { get; set; }
        // instructions to Json.NET
        public bool ShouldSerializeFields()
        {
            return FieldTemplate_JSONSerialization_Switches.Fields;
        }
        public bool ShouldSerializeFormats()
        {
            return FieldTemplate_JSONSerialization_Switches.Formats;
        }
    }

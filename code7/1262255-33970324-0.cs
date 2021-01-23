    [TypeConverter(typeof(MyReferenceTypeonverter))]
    [DesignerSerializer(typeof(MyObjectSerializer), typeof(CodeDomSerializer))]
    public abstract class MyReferencableObject
    {
        internal FieldInfo FieldInfo { get; set; }
        //Could also use: FieldInfo.DeclaringType.FullName + "." + FieldInfo.Name;
        public string FullName { get { return FieldInfo.DeclaringType.Name + "." + FieldInfo.Name; } }
    }

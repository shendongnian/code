    [DataContract]
    public class ExampleDto
    {
        [DataMember(Name="prop1", EmitDefaultValue=false)]
        public string Prop1 {get;set;}
        [DataMember(Name="prop2", EmitDefaultValue=false)]
        public string Prop2 {get;set;}
        [DataMember(Name="prop3", EmitDefaultValue=false)]
        public string Prop3 {get;set;}
        [DataMember(Name="prop4", EmitDefaultValue=false)]
        public string Prop4 {get;set;}
    }

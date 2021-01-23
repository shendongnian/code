    <!-- language: c# -->
    public class User
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "name")]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "department")]
        public string Department { get; set; }
        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
    void SomeFunction()
    {
        string json = @"{ 'name': 'Bob Smith', 'department': null }";
        var user = JsonConvert.DeserializeObject<User>(json);
        // Inspecting user here will show the Name property with the correct
        // value, the Department property with a null value, but will also
        // have a "department = null" key / value pair incorrectly in the
        // AdditionalData property.
    }

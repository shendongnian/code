    class Row
    {
        [XmlElement("Setting")] Setting[] Settings { get; set; } //Use an array of 3 elements here. A list should work as well. 
    }
    
    class Setting
    {
        [XmlElement] public string Column { get; set; }
        [XmlElement] public string Value { get; set; }
    }

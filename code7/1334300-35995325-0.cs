    public class ControlContainer : IXmlSerializable
    {
        // a single / array of / list of BaseControls
        public BaseControl Control { get; set; }
        // … any other properties
        // … implement IXmlSerializable here to have Control 
        // and any other properties (de)serialized
    }

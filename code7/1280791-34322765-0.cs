    public class Foo
    {
        private string myField;
        private bool myFieldSerializes;
        //Parameterless construction for serializing purposes
        public Foo() { }
        public Foo(string myField, bool myFieldSerializes)
        {
            this.myField = myField;
            this.myFieldSerializes = myFieldSerializes;
        }
        [XmlElement(IsNullable = true)] // Emit a value even when null as long as MyFieldSpecified == true
        public string MyField
        {
            get { return this.myField; }
            set { this.myField = value; }
        }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MyFieldSpecified { get { return myFieldSerializes; } set { myFieldSerializes = value; } }
    }

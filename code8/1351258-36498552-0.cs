    public class Orders
    {
        public List<Person> Persons;
    }
     public void SerializeObject(string filename)
        {
            // Each overridden field, property, or type requires 
            // an XmlAttributes instance.
            XmlAttributes attrs = new XmlAttributes();
            // Creates an XmlElementAttribute instance to override the 
            // field that returns Book objects. The overridden field
            // returns Expanded objects instead.
            XmlElementAttribute attr = new XmlElementAttribute();
            attr.ElementName = "Student";
            attr.Type = typeof(Student);
            XmlElementAttribute attrE = new XmlElementAttribute();
            attrE.ElementName = "Employee";
            attrE.Type = typeof(Employee);
            // Adds the element to the collection of elements.
            attrs.XmlElements.Add(attr);
            attrs.XmlElements.Add(attrE);
            // Creates the XmlAttributeOverrides instance.
            XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
            // Adds the type of the class that contains the overridden 
            // member, as well as the XmlAttributes instance to override it 
            // with, to the XmlAttributeOverrides.
            attrOverrides.Add(typeof(Orders), "Persons", attrs);
            // Creates the XmlSerializer using the XmlAttributeOverrides.
            XmlSerializer s =
            new XmlSerializer(typeof(Orders), attrOverrides);

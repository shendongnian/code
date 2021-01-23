    [System.Xml.Serialization.XmlRoot("ArrayOf__ptd_student_charges")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/something.something", IsNullable = false)]
    public class StudentCollection
    {
        [XmlArray("ArrayOf__ptd_student_charges")]
        [XmlArrayItem("__ptd_student_charges", typeof(Student))]
        public Student[] StudentArray { get; set; }
    }

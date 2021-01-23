    public ActionResult SerializePersonCollectionByXml()
    {
        var list = new List<Person> {
            new Person {Name = "John Doe", Age = 57},
            new Person {Name = "Doe, Jane"}
        };
        return new XmlResult(
            list,
            "PersonCollectionByXml.xml"
        );
    }
    // GET api/SerializationTest
    public ActionResult SerializeEmployeeCollectionByXml()
    {
        var list = new List<Employee> {
            new Employee {Name = "John Doe", Age = 57},
            new Employee {Name = "Doe, Jane"}
        };
        return new XmlResult(
            list,
            "EmployeeCollectionByXml.xml"
        );
    }

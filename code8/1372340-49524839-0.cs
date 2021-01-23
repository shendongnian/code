    using System.Xml.Linq;
    
        class Student { 
        
        
                public int id;
                public string name;
                public string surname;
                public Type type;
        
                public Student(int id, string name, string surname, Type type)
                {
                    this.id = id;
                    this.name = name;
                    this.surname = surname;
                    this.type = type;
                }
            }
        
           
            class Type
            {
                public string ID;
                public string name;
        
                public Type(string ID, string name)
                {
                    this.ID = ID;
                    this.name = name;
                }
            }
        
            class Program
            {
                static void Main(string[] args)
                {
                    Type type1 = new Type("IRT", "info");
                    Type type2 = new Type("MATH", "mathematic");
                    List<Student> Students = new List<Student>();
                    Students.Add(new Student(10, "Jon", "Snow", type1));
                    Students.Add(new Student(11, "Ned", "Stark", type2));
                    //Save Students to XML
        
                    
                    XElement xmlElements = new XElement("Students");
                    foreach (Student student in Students)
                    {
                        var xmlstudent     = new XElement("student");
                        var xmlstudenttype = new XElement("studenttype");
        
                        xmlstudenttype.Add(new XAttribute("ID", student.type.ID),
                                           new XAttribute("name",student.type.name));
                        xmlstudent.Add(new XAttribute("id", student.id),
                                       new XAttribute("name", student.name),
                                       new XAttribute("surname", student.surname), 
                                       new XElement("type", xmlstudenttype));
        
                        xmlElements.Add(xmlstudent);
                    }
                
                    System.Console.Write(xmlElements);
                    System.Console.Read();
                }
            }

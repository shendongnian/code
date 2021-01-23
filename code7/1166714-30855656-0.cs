    [XmlRoot("Employees")]
        [Serializable]
        public class MyWrapper
        {
            [XmlElement("Employee")]
            public List<Employee> Items { get; set; }
            public MyWrapper()
            {
                Items = new List<Employee>();
            }
        }
        public class Selection
        {
            [XmlIgnore]
            MyWrapper wrap = new MyWrapper();
            [XmlElement("Employee")]
            public IEnumerable<Employee> Items { get; set; }
            public IEnumerable<Employee> AgeSelection()
            {
                Items = wrap.Items.Where(x => x.AgeP > 25);
                return Items;
            }
        }
        public static void Main()
        {
            var wrapper = new MyWrapper();
            string[] firstNames = { "Vlad", "Alexey", "Dmitriy" };
            string[] lastNames = { "Ogirenko", "Belous", "Ivanov" };
            int[] ages = { 19, 26, 33 };
            string[] departments = { ".Net Sharepoint", "Network", ".Net Sharepoint" };
            string[] address = { "Kharkov", "Kharkov", "Donetsk" };
            for (int i = 0; i < 3; i++)
            {
                Employee em = new Employee();
                em.FirstNameP = firstNames[i];
                em.LastNameP = lastNames[i];
                em.AgeP = ages[i];
                em.DepartmentP = departments[i];
                em.AddressP = address[i];
                wrapper.Items.Add(em);
                object o = typeof(Employee).GetField("EmpoyeeID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(em);
            }
            SerializeToXML(wrapper, "test.xml");
            wrapper = DeserializeFromXML();
            foreach (var el in wrapper.Items)
            {
                ChangeEmployeeId(el, el.FirstNameP, el.LastNameP);
                Console.WriteLine("#"+(wrapper.Items.IndexOf(el)+1));
                Console.WriteLine("EmployeeID: "+GetId(el));
                Console.Write(el.Show()+"\n");
                Console.WriteLine("Address: "+GetAddress(el)+"\n");
            }
            Selection select = new Selection();
            SerializeToXML(select.AgeSelection(),"22.xml");
            Console.ReadLine();
        }
        static public void SerializeToXML(object list,string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MyWrapper));
            
            using (var stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, list);
                stream.Flush();
                stream.Close();
            }
        }
        static public MyWrapper DeserializeFromXML()
        {
            List<Employee> employees = null;
            MyWrapper wrapper = null;
            XmlSerializer serializer = new XmlSerializer(typeof(MyWrapper));
            string path = "test.xml";
            var stream = new FileStream(path, FileMode.Open);
            wrapper = (MyWrapper)serializer.Deserialize(stream);
            stream.Close();
            employees = wrapper.Items;
            return wrapper;
        }

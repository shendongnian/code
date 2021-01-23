    public class MyObject {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
    }
    
    public class TestReflection {
        public void Test() {
            var obj = new MyObject();
    
            UpdateObject(obj, "Name", "THis is a name");
            UpdateObject(obj, "Age", 99);
            UpdateObject(obj, "Nickname", "This is a nickname");
    
            Console.WriteLine("{0} {1} {2}", obj.Name, obj.Age, obj.Nickname);
            Console.ReadLine();
        }
    
        private void UpdateObject(MyObject obj, string varName, object varValue) {
            //Get Properties of the object
            var properties = obj.GetType().GetProperties();
            //Search for the property via the name passed over to the method.
            var prop = properties.FirstOrDefault(_ => _.Name.Equals(varName, StringComparison.InvariantCultureIgnoreCase));
            //Check prop exists and set to the object.
            if(prop != null) {
                prop.SetValue(obj, varValue);
            }
        }
    }

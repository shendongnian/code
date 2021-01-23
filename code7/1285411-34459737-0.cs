    namespace WpfApplication3
    {
        public partial class App : Application
        {
            string path = @"C:\Users\xxx\Desktop\myFile.dat";
            public App()
            {
                InitializeComponent();
                //Test
                List<Employee> myList = new List<Employee>();
                myList.Add(new Employee("aaa"));
                myList.Add(new Employee("bbb"));
                SaveToFile(myList); //Save to file
                List<Employee> myNewList = LoadFromFile(); //Load from file
                foreach (var e in myNewList)
                    Console.WriteLine(e.name);
            }
            public void SaveToFile(List<Employee> objectToSerialize)
            {
                Stream stream = File.Open(path, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
                stream.Close();
            }
            public List<Employee> LoadFromFile()
            {
                if (!System.IO.File.Exists(path))
                    return new List<Employee>();
                List<Employee> objectToSerialize;
                Stream stream = File.Open(path, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (List<Employee>)bFormatter.Deserialize(stream);
                stream.Close();
                return objectToSerialize;
            }
        }
        [Serializable()]
        public class Employee
        {
            public string name = "";
            public Employee(string eName)
            {
                name = eName;
            }
        }
    }

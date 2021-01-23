    namespace WpfApplication3
    {
        public partial class App : Application
        {
            string path = @"C:\Users\GenkCapital\Desktop\myFile.dat";
            public App()
            {
                InitializeComponent();
                //Test
                List<Employee> eList = new List<Employee>();
                eList.Add(new Employee("aaa"));
                eList.Add(new Employee("bbb"));
                List<Supervisor> sList = new List<Supervisor>();
                sList.Add(new Supervisor("ccc"));
                sList.Add(new Supervisor("ddd"));
                SavedInfo savedInfo = new SavedInfo();
                savedInfo.employeeList = eList;
                savedInfo.supervisorList = sList;
                SaveToFile(savedInfo); //Save to file
                SavedInfo newSaveGame = LoadFromFile(); //Load from file
                foreach (var e in newSaveGame.employeeList)
                    Console.WriteLine("Employee: " + e.name);
                foreach (var e in newSaveGame.supervisorList)
                    Console.WriteLine("Supervisor: " + e.name);
            }
            public void SaveToFile(SavedInfo objectToSerialize)
            {
                Stream stream = File.Open(path, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
                stream.Close();
            }
            public SavedInfo LoadFromFile()
            {
                if (!System.IO.File.Exists(path))
                    return new SavedInfo();
                SavedInfo objectToSerialize;
                Stream stream = File.Open(path, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (SavedInfo)bFormatter.Deserialize(stream);
                stream.Close();
                return objectToSerialize;
            }
        }
        [Serializable()]
        public class SavedInfo
        {
            public List<Employee> employeeList = new List<Employee>();
            public List<Supervisor> supervisorList = new List<Supervisor>();
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
        [Serializable()]
        public class Supervisor
        {
            public string name = "";
            public Supervisor(string eName)
            {
                name = eName;
            }
        }
    }

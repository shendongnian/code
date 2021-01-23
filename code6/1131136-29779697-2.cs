    public class Student
    {
        private static int _curID = 1000;
        public static int GenerateNextID()
        {
            var id = _curID;
            _curID++;
            return id;
        }
        public string FullName { get; set; }
        public int StudentID { get; private set; }
        //constructor to initialize FullName and StudentID
        public Student(string name, int ID)
        {
            FullName = name;
            StudentID = ID;
        }
        public override string ToString()
        {
            return string.Format("ID: {0}\n Name: {1}", StudentID, FullName);
        }
    }

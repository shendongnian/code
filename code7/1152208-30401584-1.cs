    static void Main(string[] args) {
     Console.WriteLine("Please enter the number of students: ");
     Cunt = int.Parse(Console.ReadLine());
     University university = new University(Cunt);
     university.AddStudent(new Student() /*Student logic here.*/);
     university.Sort();
     university.Report();
    }
    class Student {
     //Properties here...
     public Student(){
          //Default values here...
     }
    }
    class University {
     private List<Student> _Students;
     public Students {
          get {
               return _Students;
          }
          //In Microsoft's guidelines, list shouldn't be exposed as properties.
          protected set {
               //Add list replacement logic here.
               _Students = value;
          }
     }
     public University(Int32 StudentCount) {
          _Students = new List<Student>(new Student[StudentCount]);
     }
     public void AddStudent(Student StudentToAdd) {
          //Add your logic here...
          _Students.Add(StudentToAdd);
     }
    }

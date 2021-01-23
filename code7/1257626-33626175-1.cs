    public abstract class Student
    {
        public abstract void changeName(string newName);
        public abstract void outputDetails();
    }
    public class CollegeStudent : Student
    {
        public string firstName;
        public string lastName;
        public string major;
        public double GPA;
        public override void changeName(string newName)
        {
              firstName = newName;
        }
        public override void outputDetails()
        {
            Console.WriteLine("Student " + firstName + ");
        }
    }

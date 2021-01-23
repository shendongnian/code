    public abstract class Student
    {
        public string firstName;
        public string lastName;
        public virtual void changeName(string newName)
        { 
            firstName = newName;
        }
        public abstract void outputDetails();
    }
    public class CollegeStudent : Student
    {
        public string major;
        public double GPA;
        public override void outputDetails()
        {
            Console.WriteLine("Student " + firstName + ");
        }
    }

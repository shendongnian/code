       class Program
       {
         static void Main(string[] args)
        {
                    StudentServiceProxy myclient;
                    myclient = new StudentServiceProxy();
                    int studentId = 1;
                    Console.WriteLine(“Calling StudentService with StudentId =1…..”);
                    Console.WriteLine(“Student Name = {0}”, myclient.GetStudentInfo(studentId));
                    Console.ReadLine();
        }
    }

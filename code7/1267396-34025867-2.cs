    class Program
    {
        static void Main(string[] args)
        {
            ISalerySubject salery = new SalerySubject();
            TeacherObserver teacher = new TeacherObserver();
            teacher.Subject = salery;
            Console.WriteLine("Teacher is " + teacher.Mood);
            salery.Salery = 100 ;
            Console.WriteLine("Teacher salery just went down. The teacher is now " + teacher.Mood);
        }
    }	
	

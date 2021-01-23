    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
    	public static void Main()
        {
            List<StudentClass> ListOfStudents = StudentClass.GetStudents();
            ListOfStudents.ForEach(i => Console.WriteLine("{0}", i.Name));
            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadKey();
        }
    }

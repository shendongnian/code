    public class Class : People
    {
        static People[] students = new People[5];
        public override void insertDetail(People stu)
        {
            Console.WriteLine("==================================");
            base.insertDetail(stu);
        }
    
    
        public static void Main(string[] args)
        {
    		Class c = new Class(); // this is required to access insertDetail
    
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new People();
                c.insertDetail(students[i]);
            }
    
            Console.ReadKey();
        }
    }

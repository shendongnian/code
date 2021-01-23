    class Program
    {
        static void Main()
        {
            ObjStruct[] array = new ObjStruct[10];
            Console.WriteLine(array[0].Test);
        
            ObjClass[] array = new ObjClass[10];
            Console.WriteLine(array[0].Test); //NullReferenceException
        }
    }
    public class ObjClass
    {
        public string Test { get { return "Not null"; } }
    }
    public struct ObjStruct
    {
        public string Test { get { return "Not null"; } }
    }

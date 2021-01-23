    public class MyClass
    {
        public MyClass() 
        {
            MyStruct child1 = new MyStruct( "abc" );
            // should print "abc"
            Console.WriteLine(child1.SomethingImportant);
            MyStruct child2 = 7.5;
            // should print out what?
            Console.WriteLine(child2.SomethingImportant);
        }
    }

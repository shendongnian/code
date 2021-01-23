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
            MyStruct child3 = new MyStruct( "cde" );
            child3 = 5.7;
            // will never, ever print "cde" (if not static)
            Console.WriteLine(child2.SomethingImportant);
        }
    }

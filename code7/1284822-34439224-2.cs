    abstract class BinaryCommand
    {
        MyBaseCommand child1;
        MyBaseCommand child2;
    
        abstract object Execute();
    }
    
    class ExampleCommand1 : BinaryCommand
    {
        override object Execute()
        {
             //DoStuff1...
        }
    }
    
    class ExampleCommand2 : BinaryCommand
    {
        override object Execute()
        {
             //Do Somethign else
        }
    }

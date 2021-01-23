    public class SomeFieldsGrouped{
        public int foo {get;set;}
        public string bar {get;set;}
        //<etc>
    }
    
    public class A{
        public SomeFieldsGrouped someFieldsGroupedInA {get;set;} 
        //<etc>
    }
    public class B : A{
        public int ffo {get;set;}
        //<etc>
    }

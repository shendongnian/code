    // Here's some example type definitions
    public enum MyEnum {One, Two, Three};
    public class MyClass : BaseClass {
        public MyEnum EnumValue {get;set;}
    }
    public class MyList : List<MyClass>
    // Here's how you'd use them
    public void DoStuff() {
        var list = new MyList();  // or new List<MyClass>();
        list.Add(
            new MyClass{ EnumValue = MyEnum.One },
            new MyClass{ EnumValue = MyEnum.Two }
        );
        foreach (var item in list) 
        {
            Console.WriteLine(item.EnumValue.ToString();
        }
    }

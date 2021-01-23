using System;
using System.Collections;
using System.Collections.Generic;
				
public interface MyInterfaceFunc {
	void Call<T>(MyInterface<T> obj);
}
public interface MyInterface {
    void Generically(MyInterfaceFunc func);  // this is the key!
}
public interface MyInterface<T> : MyInterface
{
    T GetSomething();
    void DoSomething(T something);
}
public class MyIntClass : MyInterface<int>
{
    public int GetSomething()
    {
        return 42;
    }
    public void DoSomething(int something)
    {
        Console.Write(something);
    }
    public void Generically(MyInterfaceFunc func) {
        func.Call(this);
    }
}
public class MyStringClass : MyInterface<string>
{
    public string GetSomething()
    {
        return "Something";
    }
    public void DoSomething(string something)
    {
        Console.Write(something);
    }
    public void Generically(MyInterfaceFunc func) {
        func.Call(this);
    }
}
public class MyFunc : MyInterfaceFunc {
    public void Call<T>(MyInterface<T> thingDoer) {
        T something = thingDoer.GetSomething();
        thingDoer.DoSomething(something);
        thingDoer.DoSomething(something);
    }
}
public class Program {
	public static void Main(){
		var listOfThings = new List<MyInterface>(){
			new MyIntClass(),
			new MyStringClass()
		};
		foreach (MyInterface thingDoer in listOfThings){
			thingDoer.Generically(new MyFunc());
		}
	}
}

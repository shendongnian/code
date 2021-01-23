    public interface IWork
    {
    void func();
    }
    public abstract class WorkClass,IWork
    {
    public void func()
    {
        Console.WriteLine("Calling Abstract Class Function");
    }}
    public class MyClass:WorkClass{
    ...
    }

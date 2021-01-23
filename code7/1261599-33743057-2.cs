    public class MyEventHandler(object sender, string e)
    {
      Console.WriteLine("Event Attached!");
    }
    private TestClass mytest= new TestClass(MyEventHandler);

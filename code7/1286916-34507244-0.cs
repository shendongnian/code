    public class MyEventClass {
    private event EventHandler test;
    public event EventHandler TestEven {
      add { test += value; }
      remove { test -= value; }
    }

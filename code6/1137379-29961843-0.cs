    public interface IClass1 {
      string pr1 { get; }
      string pr2 { get; }
    }
    internal class Class1Adapter : IClass1 {
      public static Class1Adapter FromClass1(Class1 class1) {
        var pr1 = class1.pr1;
        var pr2 = class1.pr2;
        return new Class1Adapter {pr1 = pr1, pr2 = pr2};
      }
      public string pr1 { get; private set; }
      public string pr2 { get; private set; }
    }

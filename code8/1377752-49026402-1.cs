    public class ChildTest : ParentTest, ITest
    {
      string ITest.Speak()
      {
        return "Mooo" + typeof(ParentTest).GetMethod("ITest.Speak", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, new object[0]) as string;
      }
    }

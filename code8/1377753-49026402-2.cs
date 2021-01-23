    public class ChildTest : ParentTest, ITest
    {
      static ChildTest()
      {
        baseSpeakMethodInfo = typeof(ParentTest).GetMethod("ITest.Speak", BindingFlags.Instance | BindingFlags.NonPublic);
      }
      static private MethodInfo baseSpeakMethodInfo;
      public ChildTest()
      {
        baseSpeak = baseSpeakMethodInfo.CreateDelegate(typeof(Func<string>), this) as Func<string>;
      }
      private Func<string> baseSpeak;
      string ITest.Speak()
      {
        return "Mooo" + baseSpeak();
      }
    }

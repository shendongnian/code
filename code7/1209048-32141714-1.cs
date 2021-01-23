    internal class Program
    {
       private static void Main(string[] args)
       {
          RootNode obj = new RootNode();
          obj.introductionActions.Add(new IntroductionActionComplex() { question = "qTest", answerStrings = { "aTest1", "aTest2" }, name = "aName1" });
          obj.introductionActions.Add(new IntroductionActionSimple() { name = "aName2", Value = "aValue" });
          RootNode.SaveToFile(obj, "Test.xml");
          RootNode obj2 = RootNode.LoadFromFile("Test.xml");
       }
    }

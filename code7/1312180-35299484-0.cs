    [Guid("149F7A5F-7DAC-4426-8AA0-28975A2CE203")]
    [ComVisible(true)]
    public interface ITest
    {
        string testLT(string FilePath, object Args);
        string RemoveListTemplates(string FilePath, object Args);
        void test(string arg);
    }
    [Guid("D86307C2-3FFA-4518-BABC-DA5F26ABC445")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class Test : ITest

    public abstract class Base
    {
    }
    public static class GenericBase<T>
        where T : Base
    {
        public static List<T> LoadFromXml(string path)
        {
            //Load from XML
        }
    }
    public class Base1 : Base { }
    public class Base2 : Base { }
    public class Test //MainForm.cs class or whatever you want
    {
        public void Tester() //Load event handler or whatever you want
        {
            List<Base1> base1List = PrepareBase<Base1>();
        }
        public List<T> PrepareBase<T>() where T : Base
        { return GenericBase<T>.LoadFromXml("C:\test.xml"); }
    }

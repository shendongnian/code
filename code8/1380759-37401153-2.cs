    public abstract class Base
    {
        public static List<T> LoadFromXml<T>(string path) where T : Base, new()
        {
            List<T> baseList = new List<T>();
            XDocument doc = XDocument.Load(path);
            foreach (var node in doc.Descendants(typeof(T).Name))
            {
                T t = new T();
                Dictionary<string, string> d = new Dictionary<string, string>();
                foreach (var item in node.Elements())
                    d.Add(item.Name.ToString(), item.Value);
                t.Load(d);
                baseList.Add(t);
            }
            return baseList;
        }
        protected internal abstract void Load(Dictionary<string, string> elements);
    }
    public class Base1 : Base
    {
        public string CustomProp1 { get; set; }
        public string CustomProp2 { get; set; }
        public string CustomProp3 { get; set; }
        protected internal override void Load(Dictionary<string, string> elements)
        {
            if (elements.ContainsKey("CustomProp1"))
                CustomProp1 = elements["CustomProp1"];
            if (elements.ContainsKey("CustomProp2"))
                CustomProp2 = elements["CustomProp2"];
            if (elements.ContainsKey("CustomProp3"))
                CustomProp3 = elements["CustomProp3"];
        }
    }
    public class Base2 : Base
    {
        public string CustomProp1 { get; set; }
        public string CustomProp2 { get; set; }
        public string CustomProp3 { get; set; }
        protected internal override void Load(Dictionary<string, string> elements)
        {
            if (elements.ContainsKey("CustomProp1"))
                CustomProp1 = elements["CustomProp1"];
            if (elements.ContainsKey("CustomProp2"))
                CustomProp2 = elements["CustomProp2"];
            if (elements.ContainsKey("CustomProp3"))
                CustomProp3 = elements["CustomProp3"];
        }
    }
    public class Test //MainForm.cs class or whatever you want
    {
        public void Tester() //Load event handler or whatever you want
        {
            List<Base1> base1List = PrepareBase<Base1>();
        }
        public List<T> PrepareBase<T>() where T : Base, new()
        {
            return Base.LoadFromXml<T>("C:\test.xml");
        }
    }

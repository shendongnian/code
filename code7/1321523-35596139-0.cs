    class Program
    {  
        static void Main()
        {
            var root = new MyXmlRoot
            {
                Items = {
                    new Bar { },
                    new Blap { },
                    new Bar { },
                }
            };
            var ser = new XmlSerializer(typeof(MyXmlRoot));
            ser.Serialize(Console.Out, root);
        }
    }
    
    public abstract class Foo { } // base type used for the list
    public class Bar : Foo {
        // more props here
    }
    public class Blap : Foo {
        // more props here
    }
    public class MyXmlRoot
    {
        private readonly List<Foo> items = new List<Foo>();
        [XmlElement("E1WPUO2", typeof(Bar))]
        [XmlElement("E1WPUO3", typeof(Blap))]
        public List<Foo> Items { get { return items; } }
    }

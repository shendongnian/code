    namespace HashSetIntersect
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
            InitializeComponent();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            HashSet<TestHashKey> TestHashKeys1 = new HashSet<TestHashKey>();
            HashSet<TestHashKey> TestHashKeys2 = new HashSet<TestHashKey>();
            for (UInt32 i = 0; i < 10000000; i++)
            {
                Guid g = Guid.NewGuid();
                TestHashKeys1.Add(new TestHashKey(g));
                if (i % 2 == 0) TestHashKeys2.Add(new TestHashKey(g));
            }
            HashSet<TestHashKey> TestHashKeys3 = new HashSet<TestHashKey>(TestHashKeys1);
            Debug.WriteLine(TestHashKeys1.Count.ToString() + " " + TestHashKeys2.Count.ToString());
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
            sw.Restart();
            TestHashKeys3.IntersectWith(TestHashKeys2);
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
            }
        }
        public abstract class HashKey : Object
        {
            public Guid ObjectId { get; private set; }
            public override bool Equals(object obj)
            {
                if (!(obj is HashKey)) return false;
                HashKey comp = (HashKey)obj;
                return this.ObjectId == comp.ObjectId;
            }
    
            public override int GetHashCode()
            {
                return ObjectId.GetHashCode();
            }
            public HashKey(Guid objectId)
            {
                ObjectId = objectId;
            }
        }
        public class TestHashKey : HashKey
        {
            public TestHashKey(Guid ObjectId)
                : base(ObjectId)
            { }
        }   
    }

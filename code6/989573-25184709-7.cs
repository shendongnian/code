    using System.Diagnostics;
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
                HashSet<AuditCache> TestHashKeys1 = new HashSet<AuditCache>();
                HashSet<AuditCache> TestHashKeys2 = new HashSet<AuditCache>();
                for (UInt32 i = 0; i < 1000000; i++)
                {
                    Guid g = Guid.NewGuid();
                    TestHashKeys1.Add(new AuditCache(g, 1, (DateTime?)null, (DateTime?)null, "value1"));
                    if (i % 2 == 0) TestHashKeys2.Add(new AuditCache(g, 0, (DateTime?)null, (DateTime?)null, "value2"));
                }            
                Debug.WriteLine(TestHashKeys1.Count.ToString() + " " + TestHashKeys2.Count.ToString());
                sw.Stop();
                Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
                sw.Restart();
                HashSet<AuditCache> TestHashKeys3 = new HashSet<AuditCache>(TestHashKeys1);
                sw.Stop();
                Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
                sw.Restart();
                TestHashKeys3.IntersectWith(TestHashKeys2);
                sw.Stop();
                Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
                foreach (AuditCache ac in TestHashKeys3)
                {
                    Debug.WriteLine(ac.Value);
                }
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
        public class AuditCache : HashKey
        {
            public int HistoryId { get; private set; }
            public DateTime? DateFrom { get; private set; }
            public DateTime? DateTo { get; private set; }
            public string Value { get; private set; }
            public AuditCache(Guid objectId, int historyId, DateTime? dateFrom, DateTime? dateTo, string value)
                : base(objectId)
            {
                HistoryId = historyId;
                DateFrom = dateFrom;
                DateTo = dateTo;
                Value = value;
            }
        }
    }

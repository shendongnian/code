    class Program {
        static void Main() {
            var items = new IDataItem[] {
                new TestItem(),
                new TestItem(),
                new TestItem2(),
                new TestItem2(),
            };
            foreach (var kv in items.GroupBy(c => c.GetType())) {
                // group by actual type
                var type = kv.Key;
                var batch = kv.ToArray();
                // grab BulkInsert<Type> method
                var insert = typeof(Test).GetMethod("BulkInsert").MakeGenericMethod(type);
                // create array of Type[]
                var casted = Array.CreateInstance(type, batch.Length);
                Array.Copy(batch, casted, batch.Length);
                // invoke
                insert.Invoke(new Test(), new object[] { casted});
            }            
            
            Console.ReadKey();
        }        
    }
    public interface IDataItem {
        
    }
    public class TestItem : IDataItem {
        
    }
    public class TestItem2 : IDataItem
    {
    }
    public class Test {
        public void BulkInsert<T>(IEnumerable<T> items) {
            Console.WriteLine(typeof(T).Name);
        }
    }

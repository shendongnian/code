         namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] arr = new int[] { 1, 2, 1, 4, 5, 1, 2, 2, 2 };
                int occurrenceLimit = 2;
                var newList = new List<Vm>();
    
                
                var result=new List<Vm>();
    
                for (int i = 0; i < arr.Length; i++)
                {
                    var a = new Vm {Value = arr[i], Index = i};
                    result.Add(a);
                }
    
                foreach (var item in result.GroupBy(x => x.Value))
                {
                    newList.AddRange(item.Select(x => x).Take(occurrenceLimit));
                }
    
                Console.WriteLine(string.Join(",",newList.OrderBy(x=>x.Index).Select(a=>a.Value)));
    
                Console.ReadKey();
            }
        }
    
        public class Vm
        {
            public int Value { get; set; }
            public int Index { get; set; }
        }
    }

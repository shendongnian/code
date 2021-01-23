    class Program
    {
        static void Main(string[] args)
        {
            var merger = new CsvMerger(Console.Out);
            Guid type1 = merger.RegisterType(new [] { "Element1", "Element2", "Element3" });
            Guid type2 = merger.RegisterType(new[] { "Element3", "Element5", "Element6" });
            merger.WriteHeaders();
            merger.WriteData(type1, "00000001", "00000002", "00000003");
            merger.WriteData(type2, "00000003", "00000005", "00000006");
        }
    }
    public class CsvMerger
    {
        readonly TextWriter output;
        const string OutputSeparator = "|";
        bool canAddTypes = true;
        readonly List<string> fieldNames = new List<string>(); 
        readonly Dictionary<Guid, int[]> positionMap = new Dictionary<Guid, int[]>(); 
        
        public CsvMerger(TextWriter output)
        {
            this.output = output;
        }
        public Guid RegisterType(params string[] dataLayout)
        {
            if (!this.canAddTypes)
                throw new InvalidOperationException("Already started writing data, cannot add more source types");
            int[] positions = new int[dataLayout.Length];
            for (int i = 0; i < dataLayout.Length; i++)
            {
                int position = this.fieldNames.IndexOf(dataLayout[i]);
                if (position == -1)
                {
                    positions[i] = this.fieldNames.Count;
                    this.fieldNames.Add(dataLayout[i]);
                }
                else
                {
                    positions[i] = position;
                }
            }
            Guid typeKey = Guid.NewGuid();
            this.positionMap[typeKey] = positions;
            return typeKey;
        }
        public void WriteHeaders()
        {
            Console.WriteLine(string.Join(OutputSeparator, this.fieldNames));
        }
        public void WriteData(Guid type, params string[] data)
        {
            this.canAddTypes = false;
            int[] map = this.positionMap[type];
            string[] arrangedDataBuffer = new string[this.fieldNames.Count];
            for (int i = 0; i < data.Length; i++)
            {
                arrangedDataBuffer[map[i]] = data[i];
            }
            this.output.WriteLine(string.Join(OutputSeparator, arrangedDataBuffer));
        }
    }

     static void Main(string[] args)
        {
            DataFile myFile = new DataFile(@"C:\...");
            foreach (DataRecord item in myFile)
            {
                Console.WriteLine("ID: {0}, Name: {1}, StartDate: {2}", item.ID, item.Name, item.StartDate);
            }
            Console.ReadLine();
        }
        public class DataFile : IEnumerable<DataRecord>
        {
            HashSet<DataRecord> _items = new HashSet<DataRecord>();
            public DataFile(string filePath)
            {
                // read your file and obtain record data here... 
                //I'm not showing that
                //... then begin iterating through your string results
                //... though I'm only showing one record for this example
                DataRecord record = new DataRecord("1234|11-4-2015|John Doe");
                _items.Add(record);
            }
            public IEnumerator<DataRecord> GetEnumerator()
            {
                foreach (DataRecord item in _items)
                {
                    yield return item;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public class DataRecord
        {
            private int _id;
            public int ID
            {
                get { return _id; }
                private set { _id = value; }
            }
            private DateTime _startDate;
            public DateTime StartDate
            {
                get { return _startDate; }
                private set { _startDate = value; }
            }
            private string _name;
            public string Name
            {
                get { return _name; }
                private set { _name = value; }
            }
            internal DataRecord(string delimitedRecord)
            {
                if (delimitedRecord == null)
                    throw new ArgumentNullException("delimitedRecord");
                string[] items = delimitedRecord.Split('|');
                //You could put these in separate methods if there's a lot
                int id = 0;
                if (!int.TryParse(items[0], out id))
                    throw new InvalidOperationException("Invalid type...");
                this.ID = id;
                DateTime startDate = DateTime.MinValue;
                if (!DateTime.TryParse(items[1], out startDate))
                    throw new InvalidOperationException("Invalid type...");
                this.StartDate = startDate;
                //This one shouldn't need validation since it's already a string and 
                //will probably be taken as-is
                string name = items[2];
                if (string.IsNullOrEmpty(name))
                    throw new InvalidOperationException("Invalid type...");
                this.Name = name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = EnumerateQuantityValues("largefile.txt");
            // do whatever you need
        }
        private IEnumerable<int> EnumerateQuantityValues(string fileName)
        {
            const int columnIndex = 3;
            using (var stream = File.OpenRead(fileName))
            {
                IEnumerable<int> enumerable = stream
                    .EnumerateLines()
                    .Select(x => x.ChunkLine().GetColumnData(columnIndex))
                    .Select(int.Parse);
                foreach (var value in enumerable)
                {
                    yield return value;
                }                
            }
        }

        public void WriteLineFromCollection<T>(IEnumerable<T> line)
        {
            string newLine = String.Join(",", line);
            base.WriteLine(newLine);
        }

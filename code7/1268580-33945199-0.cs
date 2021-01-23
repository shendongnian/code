       private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string GetColumnName(int columnIndex)
        {
            if (columnIndex < 0) throw new ArgumentOutOfRangeException("columnIndex", columnIndex, "Column index index may not be negative.");
            string result = "";
            for (; ; )
            {
                result = Alphabet[(columnIndex) % 26] + result;
                if (columnIndex < 26) break;
                columnIndex = columnIndex / 26 - 1;
            }
            return result;
        }

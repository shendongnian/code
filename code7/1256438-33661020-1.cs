    enum EntryType { Single, Range, Unknown }
    struct Entry
    {
        public string Value;
        public int Number;
        public int Next; // position of the next value with the same number
        public EntryType Type;
    }
    static string Compress(IEnumerable<string> input)
    {
        var entryList = input.Select(value => new Entry { Value = value }).ToArray();
        var numberQueue = new Dictionary<int, int>(entryList.Length); // Key=number, Value=position
        for (int pos = entryList.Length - 1; pos >= 0; pos--)
        {
            var value = entryList[pos].Value;
            int number;
            if (value.Length > 1 && value[0] == '#' && int.TryParse(value.Substring(1), out number))
            {
                int nextPos;
                if (!numberQueue.TryGetValue(number, out nextPos)) nextPos = -1;
                entryList[pos].Number = number;
                entryList[pos].Type = EntryType.Unknown;
                entryList[pos].Next = nextPos;
                numberQueue[number] = pos;
            }
        }
        var output = new StringBuilder();
        for (int pos = 0; pos < entryList.Length; pos++)
        {
            var entryType = entryList[pos].Type;
            if (entryType == EntryType.Range) continue; // already processed
            var number = entryList[pos].Number;
            int startPos = pos, endPos = pos, prevCount = 0, nextCount = 0;
            if (entryType == EntryType.Unknown)
            {
                for (int prevPos; numberQueue.TryGetValue(number - prevCount - 1, out prevPos) && prevPos >= 0; startPos = prevPos, prevCount++) { }
                for (int nextPos; numberQueue.TryGetValue(number + nextCount + 1, out nextPos) && nextPos >= 0; endPos = nextPos, nextCount++) { }
                entryType = prevCount + nextCount >= 2 ? EntryType.Range : EntryType.Single;
                for (int offset = -prevCount; offset <= nextCount; offset++)
                {
                    var nextNumber = number + offset;
                    int nextPos = numberQueue[nextNumber];
                    entryList[nextPos].Type = entryType;
                    numberQueue[nextNumber] = entryList[nextPos].Next;
                }
            }
            if (output.Length > 0) output.Append(',');
            if (entryType == EntryType.Single)
                output.Append(entryList[pos].Value);
            else
                output.Append(entryList[startPos].Value).Append(':').Append(entryList[endPos].Value);
        }
        return output.ToString();
    }

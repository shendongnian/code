    public int CompareTo(SortPara other)
        {
            int shortest = this.numbers.Count < other.numbers.Count ? this.numbers.Count : other.numbers.Count;
            int results = 0;
            for (int i = 0; i < shortest; i++)
            {
                if (this.numbers[i] != other.numbers[i])
                {
                    results = this.numbers[i].CompareTo(other.numbers[i]);
                    break;
                }
            }
            if (results != 0)
                return results;
            if (this.numbers.Count > other.numbers.Count)
                return 1;
            else if (this.numbers.Count < other.numbers.Count)
                return -1;
            else
                return 0;
        }

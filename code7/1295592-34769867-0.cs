    public sealed class ObjectRegex<TValue>
    {
        //there is not much space between this two, but they are very representative.
        private const char LeftUnicodeBorder = 'a';
        private const char RightUnicodeBorder = 'z';
        public const int MaxPredicatesCount = RightUnicodeBorder - LeftUnicodeBorder + 1;
        private readonly Predicate<TValue>[] _predicates;
        private readonly Regex _pattern;
        public ObjectRegex(string str, params Predicate<TValue>[] predicates)
        {
            if (predicates == null || predicates.Length == 0)
            {
                throw new ArgumentOutOfRangeException("predicates", "Invalid count.");
            }
            if (predicates.Length > MaxPredicatesCount)
            {
                throw new ArgumentOutOfRangeException("predicates","Too many predicates.");
            }
            _predicates = predicates;
            var matches = Regex.Matches(str, @"\{(\d+)\}").Cast<Match>().Select(x=>int.Parse(x.Groups[1].Value)).Distinct();
            
            foreach (var match in matches)
            {
                if (match < 0 || match >= _predicates.Length)
                {
                    throw new ArgumentOutOfRangeException("str", "Index described in pattern should point to predicate - " + match);
                }
                str = str.Replace("{" + match + "}", GetReadableStringIndex(match));
            }
            _pattern = new Regex(str, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
        }
        public IEnumerable<ObjectRegexMatch<TValue>> Matches(TValue[] values)
        {
            var str = GetRegexString(values);
            var matches = _pattern.Matches(str);
            foreach (Match match in matches)
            {
                yield return new ObjectRegexMatch<TValue>(match, values);
            }
        }
        private string GetRegexString(IEnumerable<TValue> values)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var index in values.Select(GetIndex))
            {
                builder.Append(index);
            }
            return builder.ToString();
        }
        private string GetIndex(TValue value)
        {
            for (int i = 0; i < _predicates.Length; i++)
            {
                if (_predicates[i](value))
                {
                    return GetReadableStringIndex(i);
                }
            }
            return GetReadableStringIndex(char.MaxValue);
        }
        private static string GetReadableStringIndex(int index)
        {
            return "" + (char) (LeftUnicodeBorder + index);
        }
        public override string ToString()
        {
            return _pattern.ToString();
        }
    }
    [DebuggerDisplay("matched={IsSuccess}, index={Index}, length={Length};")]
    public class ObjectGroup<TValue> : IEnumerable<TValue>
    {
        private readonly TValue[] _collection;
        public readonly bool IsSuccess;
        public readonly int Index;
        public readonly int Length;
        public IEnumerable<TValue> Value
        {
            get
            {
                if (!IsSuccess)
                {
                    throw new InvalidOperationException("Match is not successful.");
                }
                for (int i = Index; i < Index+Length; i++)
                {
                    yield return _collection[i];
                }
            }
        }
        public ObjectGroup(Group group, TValue[] collection)
        {
            _collection = collection;
            Index = group.Index;
            Length = group.Length;
            IsSuccess = group.Success;
        }
        public IEnumerator<TValue> GetEnumerator()
        {
            return Value.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public sealed class ObjectRegexMatch<TValue> : ObjectGroup<TValue>
    {
        public readonly ObjectGroup<TValue>[] Groups;
        public ObjectRegexMatch(Match match, TValue[] collection) : base(match, collection)
        {
            Groups = match.Groups.Cast<Group>().Select(x => new ObjectGroup<TValue>(x, collection)).ToArray();
        } 
    }

    using Linq.Expressions;
    public static class MyQueryableStringExtensions
    {
        readonly static Func<char, int, IndexLetterPair> SelectCharIndexPairingClause = (c, i) => new IndexLetterPair() { Index = i, Letter = c };
        readonly static Func<IndexLetterPair, bool> WhereIsLetter = (dyn) => char.IsLetter(dyn.Letter);
        readonly static Expression<Func<string, IEnumerable<IndexLetterPair>>> ManyClause = (arr) => arr.Select(SelectCharIndexPairingClause).Where(WhereIsLetter);
        readonly static Expression<Func<IndexLetterPair, int>> OrderByIndexClause = (pairing) => pairing.Index;
        readonly static Expression<Func<IndexLetterPair, IndexLetterPair>> GroupByClause = (pairing) => pairing;
        // if IEquatable<IndexLetterPair> is implemented ? uses IEquatable<IndexLetterPair>.Equals : (IndexLetterPair() as object).Equals
        readonly static Expression<Func<IGrouping<IndexLetterPair, IndexLetterPair>, IndexLetterPair>> GroupSelectKeyClause = (pairing) => pairing.Key;
        public static IQueryable<char> SelectManyGroupedLetterChars(this IQueryable<string> words)
        {
            return words.SelectMany(ManyClause)
                .OrderBy(OrderByIndexClause)
                .GroupBy(GroupByClause)
                .Select(GroupSelectKeyClause)
                .Select((pair) => pair.Letter);
        }
    }
---
     string[] words = new string[] { "a#p#e", "#pp#e", "a##le" };                        
     
     IQueryable<string> queryableWords = words.AsQueryable();    
     IQueryable<char> queryGroupedLetterChars = queryableWords.SelectManyGroupedLetterChars();
            
     // string(char[]);
     string word = new string(queryGroupedLetterChars.ToArray()); 

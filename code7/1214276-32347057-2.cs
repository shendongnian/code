    public static IEnumerable<TFirst> Map<TFirst, TSecond, TThird, TKey>
            (
            this SqlMapper.GridReader reader,
            Func<TFirst, TKey> firstKey,
            Func<TSecond, TKey> secondKey,
            Func<TThird, TKey> thirdKey,
            Action<TFirst, IEnumerable<TSecond>> addSecond,
            Action<TFirst, IEnumerable<TThird>> addThird
            )
        {
            var result = reader.Read<TFirst>().ToList();
            var secondMap = reader
                .Read<TSecond>()
                .GroupBy(secondKey)
                .ToDictionary(g => g.Key, g => g.AsEnumerable());
            var thirdMap = reader
               .Read<TThird>()
               .GroupBy(thirdKey)
               .ToDictionary(g => g.Key, g => g.AsEnumerable());     
            foreach (var item in result)
            {
                IEnumerable<TSecond> second;
                if (secondMap.TryGetValue(firstKey(item), out second))
                {
                    addSecond(item, second);
                }
                IEnumerable<TThird> third;
                if (thirdMap.TryGetValue(firstKey(item), out third))
                {
                    addThird(item, third);
                }  
            }  
            return result.ToList();
        }
 

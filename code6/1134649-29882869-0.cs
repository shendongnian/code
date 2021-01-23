    public static class Extensions
    {
        public static IEnumerable<U> Combinations<T, U>( this IEnumerable<T> list,
                                                         Func<T, T, U> combinator )
        {
            var temp = list.ToArray();
            for( int i = 0; i < temp.Length - 1; i++ )
                for( int j = i + 1; j < temp.Length; j++ )
                    yield return combinator( temp[i], temp[j] );
        }
    }

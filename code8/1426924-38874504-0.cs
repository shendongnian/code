        static void Main( string[] args )
        {
            int T = Int32.Parse( Console.ReadLine() );
            for ( int t = 0 ; t < T ; ++t )
            {
                string line = Console.ReadLine();
                Console.WriteLine( NumAnagrammaticalPairs( line ) );
            }
        }
        static int NumAnagrammaticalPairs( string s )
        {
            int sum = 0;
            foreach ( var substrings in GetSubstringsByLength( s ) )
            {
                // Count for each string how many others are identical
                int toSum = 0;
                for ( int i = 1 ; i < substrings.Count ; i++ )
                    if ( substrings[i - 1] == substrings[i] )
                    {
                        toSum++;
                        sum += toSum;
                    }
                    else
                    {
                        toSum = 0;
                    }
            }
            return sum;
        }
        static IEnumerable<List<string>> GetSubstringsByLength( string s )
        {
            for ( int length = 1 ; length < s.Length ; length++ )
                yield return GetSubstringsOfLength( s, length );
        }
        static List<string> GetSubstringsOfLength( string s, int length )
        {
            var result = new List<string>();
            for ( int i = 0 ; i <= s.Length - length ; i++ )
            {
                var substring = s.Substring( i, length );
                result.Add( new string( substring.OrderBy( c => c ).ToArray<char>() ) );
            }
            result.Sort();
            return result;
        }

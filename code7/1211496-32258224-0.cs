    public static unsafe class FastConcat
    {
        public static string Concat( IList<string> list )
        {
            string destinationString;
            int destLengthChars = 0;
            for( int i = 0; i < list.Count; i++ )
            {
                destLengthChars += list[i].Length;
            }
            destinationString = new string( '\0', destLengthChars );
            
            unsafe
            {
                fixed( char* origDestPtr = destinationString )
                {
                    char* destPtr = origDestPtr; // a pointer we can modify.
                    string source;
                    for( int i = 0; i < list.Count; i++ )
                    {
                        source = list[i];
                        
                        fixed( char* sourcePtr = source )
                        {
                            Buffer.MemoryCopy(
                                sourcePtr,
                                destPtr,
                                long.MaxValue,
                                source.Length * sizeof( char )
                            );
                        }
                        destPtr += source.Length;
                    }
                }
            }
            return destinationString;
        }
    }

        private IEnumerable<T> Segment<T>( IEnumerator<T> iter, int size, out bool cont )
        {
            var ret= new List<T>( );
            cont = true;
            bool hit = false;
            for ( var i=0 ; i < size ; i++ )
            {
                if ( iter.MoveNext( ) )
                {
                    hit = true;
                    ret.Add( iter.Current );
                }
                else
                {
                    cont = false;
                    break;
                }
            }
            return hit ? ret : null;
        }
        /// <summary>
        /// Breaks the collection into smaller chunks
        /// </summary>
        public IEnumerable<IEnumerable<T>> Chunk<T>( IEnumerable<T> collection, int size )
        {
            bool shouldContinue = collection!=null && collection.Any();
            using ( var iter = collection.GetEnumerator( ) )
            {
                while ( shouldContinue )
                {
                    //iteration of the enumerable is done in segment
                    var result = Segment( iter, size, out shouldContinue );
                    
                    if ( shouldContinue || result != null )
                        yield return result;
                    
                    else yield break;
                }
            }
        }

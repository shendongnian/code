        public static IEnumerable<IEnumerable<int>> Combs(List<int> e, int size)
        {
            if (size == 0)
                yield return new[] { 0 };
            
            else
            {
                for (int i=0; i< e.Count; i ++)
                {                
                    if (size  == 1)                    
                        yield return new[] {e[i]};
                    foreach ( var next in Combs4(e.GetRange(i + 1, e.Count - (i + 1)), size  - 1) )
                        yield return new[] { e[i] }.Concat(next);
                }
            }                  
        }

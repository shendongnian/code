    lr = GenericRemove( lr, item => item.Weight == 7  );
    private static List<Recordo> GenericRemove(List<Recordo> lr, Func<Recordo, bool> filter)
    {
           for (int i = lr.Count-1; i > -1; i--)
            {
    
                if ( filter( lr[i]) )
                {
                    lr.RemoveAt(i);
                }
            }
            return lr;
    }

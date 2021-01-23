    public class MultiReader<TKey, TOut> : IReader<TOut>
    {
        public TOut Read(TKey input)
        {
            return ((IReader<TOut>)this).Read<TKey>(input);
        }
    
        TOut IReader<TOut>.Read<TKey1>(TKey1 input)
        {
             if (input is TKey)
            {
                object objectId = (object)input;
                TKey keyId = (TKey)objectId;
                return this.Read(keyId);
            }
    
            throw new InvalidOperationException();
        }
    }

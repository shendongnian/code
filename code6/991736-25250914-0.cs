    public class Test<TVal>
            where TVal : class
    {
        TVal[] Values;
        Action<int, TVal> UpdateMethod;
    
        public void Update(TVal[] values, Action<int, TVal> updateMethod) 
        {
            // lambda
            Parallel.For(0, values.Length, (i) => { updateMethod(i, values[i]); });
    
            // OR
    
            Values = values;
            UpdateMethod = updateMethod;
    
            Parallel.For(0, values.Length, Work);
        }
    
        void Work(int i)
        {
            UpdateMethod(i, Values[i]);
        }
    }

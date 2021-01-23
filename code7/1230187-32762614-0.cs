    public class NewDic<T>
    {
        public void Add(string key1, long key2, T value)
        {
            mDic.Add(key1, value);
            mDic.Add(key2, value);
        }
    
        public T this[string s]
        {
            get { return mDic[s]; }
        }
    
        public T this[long l]
        {
            get { return mDic[l]; }
        }
    
    
        Dictionary<object, T> mDic = new Dictionary<object, T>();
    }
    
            NewDic<long> dic = new NewDic<long>();
    
            dic.Add("abc", 20, 10);
    
            Console.WriteLine(dic["abc"]);
            Console.WriteLine(dic[20]);

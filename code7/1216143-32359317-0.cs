    interface IGetter1<T1,T2>
    {
        T2 Get(T1 x);
    }
    interface IGetter2<T1, T2>
    {
        T2 Get(T1 x);
    }
    public class TwoWayMap<T1, T2> : IGetter1<T1,T2>,IGetter2<T2,T1>
    {
        public T2 Get(T1 x)
        {
            throw new System.NotImplementedException();
        }
        public T1 Get(T2 x)
        {
            throw new System.NotImplementedException();
        }
    }
    var map1 = new TwoWayMap<int, int>();
            var map2 =(IGetter1<int,int>) map1;
            var map3 = (IGetter2<int, int>) map1;
         //   map2.Get(5);
            map3.Get(5);

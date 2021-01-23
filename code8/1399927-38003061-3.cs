    public void Test()
    {
        List<Ref<int>> ListA;
        List<Ref<int>> ListB;
        ListA = new List<Ref<int>>();
        ListA.Add(new Ref<int>(1));
        ListA.Add(new Ref<int>(2));
        ListA.Add(new Ref<int>(3));
        ListB = new List<Ref<int>>();
        Ref<int> one = ListA[0];
        ListB.Add(one);
        ListA[0].Value = 5;
        foreach (Ref<int> i in ListA)
        {
            Trace.WriteLine("ListA: " + i.Value);
        }
        foreach (Ref<int> i in ListB)
        {
            Trace.WriteLine("ListB: " + i.Value);
        }
    }
    public class Ref<T> where T : struct
    {
        public Ref(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
    }

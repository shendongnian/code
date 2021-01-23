    public class Output 
    {
        string aProperty;
        int Count;
        public override string ToString()
        {
            return string.Format("{0}: {1}", aProperty, Count);//Or whatever you want
        }
    }

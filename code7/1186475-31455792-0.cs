        static void Main(string[] args)
        {
            int N=100;
            float[] array = new float[N];
            List<float> list=new List<float>(N);
            var size=typeof(List<float>).GetField("_size", BindingFlags.Instance|BindingFlags.NonPublic);
            size.SetValue(list, N);
            // Now list has 100 zero items
        }

    public struct Vec3: IEnumerable
    {
        float[] MyVals;
        public float this[int a]
        {
            get
            {
                return MyVals[a];
            }
            set
            {
                MyVals[a] = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Add(float f)
        {
            //Your Code
        }
    }
    public class MainRoutine
    {
        public static Vec3 SuperVector = new Vec3 { 2, 5, 6 };
    }

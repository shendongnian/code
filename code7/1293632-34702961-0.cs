    [Flags]
    public enum VNodeClassID
    {
        Default = 0,
        Apple = 1 << 0,         // Apple = 1
        Orange = 1 << 1,        // Orange = 2
        Grape = 1 << 2,         // Grape = 4
        BlueBerry = 1 << 3,     // Bluebery = 8
        Watermellon = 1 << 4,   // Watermelon = 16
        // more items to be added
    }
    class Program
    {
        static Dictionary<VNodeClassID, int> validation = new Dictionary<VNodeClassID, int>();
        static void Main(string[] args)
        {
            //{     D      A=1    O=2    G=4    B=8    W=16
            //    { false, true,  true,  false, true,  true },  
            //    { false, false, true,  true,  false, true }, 
            //    { false, true,  true,  false, true,  true }, 
            //    { false, true,  false, true,  true,  false },
            //    { false, true,  true,  true,  false, true },
            //    { false, false, true,  false, true,  true }
            //};
            // set like this
            MakeCompatibe(VNodeClassID.Watermellon,VNodeClassID.Orange|VNodeClassID.BlueBerry|VNodeClassID.Watermellon);
            // or
            validation[VNodeClassID.Default] = 1 + 2 + 8 + 16;
            validation[VNodeClassID.Apple] = 2 + 4 + 16;
            validation[VNodeClassID.Orange] = 1 + 2 + 8 + 16;
            validation[VNodeClassID.Grape] = 1 + 4 + 8;
            validation[VNodeClassID.BlueBerry] = 1 + 2 + 4 + 16;
            validation[VNodeClassID.Watermellon] = 2 + 8 + 16;
            Debug.Assert(CheckCompatibe(VNodeClassID.Apple, VNodeClassID.Watermellon));
            Debug.Assert(!CheckCompatibe(VNodeClassID.Default, VNodeClassID.Grape));
        }
        static void MakeCompatibe(VNodeClassID item, params VNodeClassID[] items)
        {
            int sum = items.Sum((v) => (int)v);
            validation[item] = sum;
        }
        static bool CheckCompatibe(VNodeClassID item, VNodeClassID other)
        {
            if (validation.ContainsKey(item))
            {
                int sum = validation[item];
                return (sum & (int)other) > 0;
            }
            return false;
        }
    }

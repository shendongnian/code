    public class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
     public List<Vector2> GetBytes(byte[,] array, byte value)
        {
            List<Vector2> list = new List<Vector2>();
            int count;
            for (int i = 0; i < XSize; i++)
                for (int k = 0; k < YSize; k++)
                    if (array[i, k] == value)
                        list.Add(new Vector2 { X = i, Y = k });
            return list;
        }

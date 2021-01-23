    public class CompositeIndex
    {
        public int ArrayNumber { get; set; }
        public int ElementNumber { get; set; }
    }
    public static CompositeIndex GetIndex(int GlobalIndex, int ArrayCount, int ElementsToInterleave)
    {
        CompositeIndex index = new CompositeIndex();
        int fullArrays = GlobalIndex / ElementsToInterleave; //In your example: 16 / 16 = 1;
        index.ArrayNumber = fullArrays % ArrayCount; //In your example: 1 mod 4 = 1;
        index.ElementNumber = GlobalIndex - (fullArrays * ElementsToInterleave); //In your example: 16 - (1 * 16) = 0;
        return index;
    }

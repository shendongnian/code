    public class Items
    {
        // Omitted for brevity
        public int[] ToIntegerArray()
        {
            return new int[]{ 
               Int32.Parse(Id), 
               Int32.Parse(ItemA), 
               Int32.Parse(ItemB), 
               Int32.Parse(ItemC), 
               Int32.Parse(ItemD), 
               Int32.Parse(ItemE) 
            };	
        }
    } 

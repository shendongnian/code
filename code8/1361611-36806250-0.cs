    public static class StructureExtensions
    {
        public static void UpdateSize(this Structure structure, float size)
        {
            structure.size += size;
        }
        public static void UpdateX(this Structure structure, float x)
        {
            structure.pos_x += x;
            //any other update on strucutre
           
        }
    }

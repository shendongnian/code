    public static class MyExtension 
    
    {
        public static Loc Get_By_Id(this Locs l,int id) 
        {
            return l.SingleOrDefault(n => n.Id == id);
        }
    
        public static bool Check(this Locs l)
        {
            foreach (Loc loc in l)
            {
            ....
            }
        }
    }

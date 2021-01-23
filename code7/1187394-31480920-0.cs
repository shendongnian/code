    public static class PedExtensions
    {
        public static bool CheckIfTrue(this Ped ped)
        {
             if(ped.something != "this value")
             {
                  return true;
             }
    
             return false;
        }
    }

     public  static List<GameObject> ActiveChunks = new List<GameObject>();
    
            public static bool DeActivate(GameObject Obj)
            {
                if(true)//your condition
                {
                    return true;//do not remove the object
                }
                else
                {
                    return false;//remove the object
                }
            }
    
            public static void DeActivateAllChunks()
            {
                ActiveChunks = ActiveChunks.Where(c => DeActivate(c)).ToList();
            }

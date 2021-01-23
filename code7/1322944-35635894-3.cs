    Interface IItem
    {
     int TimeToWorkAdapt {get;}
    }
    
    //Now create a wrapper class for TargetItem and NonTargetItem
    
    Class TargetItemAdapt : TargetItem,IItem
    {
       public int TimeToWorkAdapt 
           {
               get { base.TimeToWork;}    
           }
    }
    
    Class NonTargetItemAdapt : NonTargetItem,IItem
    {
       public int TimeToWorkAdapt 
           {
               get { base.TimeToWork;}    
           }
    }
     // write a generic function which wrap calls to your do extra work method but with generic constriants to interface
    private static void _doExtraWork<T>(T members) where T : IItem
        {
              _doExtraWork(member.TimeToWorkAdapt);
           
        }

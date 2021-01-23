    public class CONSTS 
    {
      public const int  SUCCESS     = 1;
      public const int  InProgress  = 101;
    };
    
    enum EnumReplyLLI
    {
      Nothing = 0,
      SUCCESS = CONSTS.SUCCESS,     
      Busy    = CONSTS.InProgress,  
    };

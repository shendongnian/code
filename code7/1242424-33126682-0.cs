    public class CONSTS 
    {
      public const int  SUCCESS     = 1;
      public const int  InProgress  = 101;
    };
    
    enum EnumReplyLLI
    {
      Nothing = 0,
      SUCCESS = CONSTS.SUCCESS,      // C2057
      Busy    = CONSTS.InProgress,   // C2057
    };

    public class SomeOne{
    
    ISomeTwo _forInternalUse;
      public SomeOne(ISomeTwo passedThroughConstructor){
         _forInternalUse = passedThroughConstructor;
      }
      
      public void SomeOtherMethod(){
          _forInternalUse.DoStuff();
       }
    }

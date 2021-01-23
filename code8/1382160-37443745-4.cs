    public class MyClass2 : BaseMyThirdParty<ThirdPartyObject2> 
    { 
        public MyClass2(ThirdPartyObject2 originalObject) {
          this.OriginalObject = originalObject;
        }       
    }
    public class MyClass3 : BaseMyThirdParty<ThirdPartyObject3> { 
        public MyClass3(ThirdPartyObject3 originalObject) {
          this.OriginalObject = originalObject;
        }       
    }

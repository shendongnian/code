    public class MyClass1 : BaseMyThirdParty<ThirdPartyObject1>
    {
        public override ThirdPartyObject1 LoadObject(string param)
        { 
          // Load object in a different way
        }   
        public ThirdPartyObject1 LoadObject(string param, string param2)
        { 
         // Load object with two different parameters 
        }   
    }

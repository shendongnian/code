    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public [OBJECT] PostGenericObjects(object obj)
        {
            string[] str = GeneralMethods.UnWrapObjects(obj);
            var item1 = JsonConvert.DeserializeObject<ObjectType1>(str[0]);
            var item2 = JsonConvert.DeserializeObject<ObjectType2>(str[1]);
            return *something*;
        } 
       

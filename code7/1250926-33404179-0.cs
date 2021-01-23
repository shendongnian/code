       public class MyHugeDictionary  
       {  
            List<Dictionary<typea, typeb> allDict= null;  
            Dictionary<typea, typeb> currDictionary ;  
  
            MyHugeDictiionary()  
            {  
                allDict = new List<Dictionary<typea, typeb>();  
                currDictionary = new Dictionary<typea, typeb);  
                allDict.Add(currDictionary);  
            }  
  
            public bool ItemExists( typea, typeb)  
            {  
                foreach( KeyValue<Dictionary<typea, typeb> kv in allDict)  
                {  
                    if( kv.ContainsKey(typea) )  
                    {  
                        return true;  
                    }  
                }  
                return false;  
            }  
  
            public Add( typea a, typeb b)  
            {  
                try  
                {  
                    if( !ItemExist( tyepa, typeb) )  // find if items is in any other dictionary first  
                    {  
                        currDictionary.Add( a, b) ;  
                    }  
                    else  { // handle dups... ; }  
                }  
                catch( CollectionSizeError x)   // look-up for actual exception
                {  
                    currDictionary = CreateDictiionary();  
                    allDict.Add( currDictionary ) ;  
                    currDictionary.Add( a,b);  
                }  
                catch( OutOfMemory y)     // look-up for actual exception
                {  
                    // oops game over for real now :(  
                }  
             }  
        }  

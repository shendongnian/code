      public static Dictionary< string, string> JsonArrayToDictionary( string strJson, string keyName,string valueName)
            {
                var array = JArray.Parse(strJson) ;
                var dictionary = JsonArrayToDictionary(array, keyName, valueName);
                return dictionary;
            }
    
            public static Dictionary<string , string > JsonArrayToDictionary(this JArray array, string keyName, string valueName)
            {
                if (array != null)
                {
                    var dict = array.ToDictionary(x => x[keyName].ToString(), x => x[valueName].ToString());
                    return dict;
                }
                return null;
            }
     [TestClass()]
        public class JsonHelperExtensionsTests
        {
            [ TestMethod()]
            public void JsonArrayToDictionaryTest()
            {
                var jsonArray= @"[{""score "":0.6990418,"" id"": ""ID1"" },{""score "":0.8079009,"" id"": ""ID2"" }]";
               var dict= JsonHelperExtensions.JsonArrayToDictionary(jsonArray, "id" , "score");
                dict.Count.Should().Be(2);
                dict[ "ID1"].Should().Be("0.6990418" );
            }
        }
     

        public static void Test()
        {
            // Note there cannot be a space between the "{" and the "_type": 
            string json = @"{
                ""WaitForClientMessagesResult"": [
                    {""__type"": ""KeepAliveMessage:#Data.WebGateway"",
                        ""MessageId"": 1,
                        ""Type"": 0,
                        ""PositionInQueue"": -1
                    }
                ]
            }";
            var result = DataContractJsonSerializerHelper.GetObject<WaitForClientMessagesResult>(json);
            var newJson = DataContractJsonSerializerHelper.GetJson(result);
            Debug.Assert(JToken.DeepEquals(JToken.Parse(json), JToken.Parse(newJson))); // No assert
        }

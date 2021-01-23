            /* using Newtonsoft.Json; */
			
			MyCustomObject myobj = MyCustomObject();
			myobj.MyIntOne = 123;
			myobj.MyBoolOne = false;
			
            string jsonString = JsonConvert.SerializeObject(
                myobj,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

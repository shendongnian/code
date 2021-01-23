            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public void GetCities()
            {           
                CityList oBoCityList = new CityList() { new City { Name = "New Delhi", ID = 1 }, new City { Name = "Kanpur", ID = 2 }, new City { Name = "Gurgaon", ID = 3 } };
                JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
                //return TheSerializer.Serialize(oBoCityList);
                Context.Response.Write(TheSerializer.Serialize(oBoCityList));
            }
            }
            public class City
            {
                public City() { }
                public string Name
                { get; set; }
                public Int32 ID
                { get; set; }
            }
            public class CityList : List<City>
            {
                public CityList() { }
            }

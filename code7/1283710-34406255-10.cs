                var jsonstring = @"{
                  ""total_items"": ""62"",
                  ""page_number"": ""6"",
                  ""page_size"": ""10"",
                  ""page_count"": ""7"",
                  ""cars"": {
                    ""car"": [
                      {
                        ""car_name"": ""Honda"",
                        ""engines"": {
                          ""engine"": [
                            {
                              ""name"": ""1.2L""
                            },
                            {
                              ""name"": ""1.8L""
                            }
                          ]
                        },
                        ""country"": ""Japan""
                      },
                      {
                        ""car_name"": ""Ford"",
                        ""engines"": {
                          ""engine"": {
                            ""name"": ""2.2L""
                          }
                        },
                        ""country"": ""Japan""
                      },
                      {
                        ""car_name"": ""VW"",
                        ""engines"": null,
                        ""country"": ""Germany""
                      }
                    ]
                  }
                }";
                var myobject = Deserialise<Rootobject>(jsonstring);
                
                //if you want to parse engines you can do something like    this.
              if (myobject.cars != null && myobject.cars.car != null && myobject.cars.car.Any())
            {
                foreach (Car car in myobject.cars.car)
                {
                    if (car.engines != null && car.engines.engine != null)
                    {
                        bool isList = false;
                        try
                        {
                            var eng = Deserialise<Engine>(car.engines.engine.ToString());
                        }
                        catch
                        {
                            isList = true;
                        }
                        if (isList)
                        {
                            try
                            {
                                var eng = Deserialise<List<Engine>>(car.engines.engine.ToString());
                            }
                            catch
                            {
                                Debug.WriteLine("Not a list");
                            }
                        }
                    }
                }
            }
                var myjson = Serialise(myobject);

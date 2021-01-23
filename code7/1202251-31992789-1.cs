    var yourobject = new RequestObject
                {
                    UserName = "UAT1206252627",
                    SecurityQuestion = new SecurityQuestion
                    {
                        Id = "Q03",
                        Answer = "Business",
                        Hint = "The answer is Business"
                    },
                };
    var json = request.JsonSerializer.Serialize(yourobject);
    request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
    IRestResponse response = client.Execute(request);

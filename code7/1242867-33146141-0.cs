        var query = Query.Matches("Name",  BsonRegularExpression.Create(new Regex(model.Name, RegexOptions.IgnoreCase)));
                    //var query1 = Query.EQ("Name", model.Name);
                    var entity = DataBase.GetCollection<Technology>(TECHNOLOGY).FindOne(query);
                    if (entity == null)
                    {
                     }

           MongoClient _client = new MongoClient();
            _database = _client.GetDatabase("Store");
            var collection = _database.GetCollection<BsonDocument>("Customers");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new BsonObjectId(new ObjectId(_id)));
            var update = Builders<BsonDocument>.Update.Set("CompanyName", CompanyName_str)
                .Set("ContactName", ContactName_str)
                .Set("ContactTitle", ContactTitle_str)
                .Set("Address", Address_str)
                .Set("City", City_str)
                .Set("Region", Region_str)
                .Set("PostalCode", PostalCode_str)
                .Set("Country", Country_str)
                .Set("Phone", Phone_str);
            try
            {
                collection.UpdateOne(filter, update);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            catch (MongoWriteException mwx)
            {
                if (mwx.WriteError.Category == ServerErrorCategory.DuplicateKey)
                {
                    // mwx.WriteError.Message contains the duplicate key error message
                }
            }

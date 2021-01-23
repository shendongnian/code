    [Test]
    public void GetPaymentLatestStatuses()
    {
        var client = new TestMongoClient();
        var database = client.GetDatabase("payments");
        var paymentRequestsCollection = database.GetCollection<BsonDocument>("paymentRequests");
        var statusesCollection = database.GetCollection<BsonDocument>("statuses");
        var payment = new BsonDocument { { "amount", RANDOM.Next(10) } };
        paymentRequestsCollection.InsertOne(payment);
        var paymentId = payment["_id"];
        var receivedStatus = new BsonDocument
                             {
                                 { "payment", paymentId },
                                 { "code", "received" },
                                 { "date", DateTime.UtcNow }
                             };
        var acceptedStatus = new BsonDocument
                             {
                                 { "payment", paymentId },
                                 { "code", "accepted" },
                                 { "date", DateTime.UtcNow.AddSeconds(+1) }
                             };
        var completedStatus = new BsonDocument
                              {
                                  { "payment", paymentId },
                                  { "code", "completed" },
                                  { "date", DateTime.UtcNow.AddSeconds(+2) }
                              };
        statusesCollection.InsertMany(new[] { receivedStatus, acceptedStatus, completedStatus });
        var groupByPayments = new BsonDocument
                              {
                                  { "_id", "$payment" },
                                  { "id", new BsonDocument { { "$first", "$_id" } } }
                              };
        var sort = Builders<BsonDocument>.Sort.Descending(document => document["date"]);
        var statuses = statusesCollection.Aggregate().Sort(sort).Group(groupByPayments).ToList();
        var statusIds = statuses.Select(x => x["id"]);
        var completedStatusDocumentsFilter =
            Builders<BsonDocument>.Filter.Where(document => statusIds.Contains(document["_id"]));
        var statusDocuments = statusesCollection.Find(completedStatusDocumentsFilter).ToList();
        foreach (var status in statusDocuments)
        {
            Assert.That(status["code"].AsString, Is.EqualTo("completed"));
        }
    }

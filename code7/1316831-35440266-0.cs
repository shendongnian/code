    [Test]
    public async void Can_Retrieve_Quote()
    {
        const int quoteid = 42;
        var quote = new objQuote() { ID = 42};
        var msList = new List<objQuoteMilestone>();
        var assignmentList = new List<objAssignment>();
        Expect.Once.On(_data).Method("RetrieveQuoteAsync").With(Is.EqualTo(quoteid)).Will(Return.Value(Task.FromResult(quote)));
        Expect.Once.On(_data).Method("RetrieveAllMilestonesForQuoteAsync").With(Is.EqualTo(quoteid)).Will(Return.Value(Task.FromResult(msList)));
        Expect.Once.On(_data).Method("RetrieveAssignmentsForQuoteAsync").With(Is.EqualTo(quoteid)).Will(Return.Value(Task.FromResult(assignmentList)));
        var biz = new QuotesBiz(_data, _empData, _logger, _mailer);
        Assert.IsNotNull(biz);
        var results = await biz.RetrieveQuoteAsync(quoteid);
        Assert.That(results != null);
    }

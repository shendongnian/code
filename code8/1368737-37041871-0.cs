        var queryForm = +new TermQuery();
        queryForm.Field = "id";
        queryForm.Value = filterModel.Id;
        var rangeQuery = +new DateRangeQuery();
        rangeQuery.Field = "datetime";
        rangeQuery.GreaterThanOrEqualTo = filterModel.DateBegin.Value.AddDays(-1);
        rangeQuery.LessThanOrEqualTo = filterModel.DateEnd.Value.AddDays(1);
        searchRequest.Query = queryForm && rangeQuery

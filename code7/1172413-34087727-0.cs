    IEnumerable<object> query = result.Select(x => new {
        Col1 = x.GetType().GetProperty("Col1").GetValue(x, null).ToString() ?? "",
        Col2 = x.GetType().GetProperty("Col2").GetValue(x, null).ToString() ?? "",
        Col3 = x.GetType().GetProperty("Col3").GetValue(x, null).ToString() ?? "",
        Col4 = x.GetType().GetProperty("Col4").GetValue(x, null).ToString() ?? "",
        Col5 = x.GetType().GetProperty("Col5").GetValue(x, null).ToString() ?? "",
    }).ToList();

    try
    {
      await SearchModel.GetRemains(search, NomenCode, ProducerName, _WithAnalog,     this.HttpContext, cancelToken);
    }
    catch (MyExpectedException)
    {
      ...
    }

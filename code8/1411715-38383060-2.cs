      try
      {
          var result = _repo.GetResult().Result;
      }
      catch (AggregateException ae)
      {
          // handle exception
      }

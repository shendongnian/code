    class MyCubeItem
    {
      public string Name { get; set; }
      public double Value { get; set; }
    }
    class MyCube : ICubeDefinition<CoacheeData, MyCubeItem>
    {
      public string DimensionName { get; set; }
      public string AggregateName { get; set; }
      public string AggregateOperator { get; set; }
      public Expression<Func<CoacheeData, string> Name
      {
        get
        {
          switch (DimensionName)
          {
            case "UserId":
              return x => x.UserId;
            ...
          }
        }
      }
      public Expression<Func<CoacheeData, string> Value
      {
        get
        {
          switch (AggregateName)
          {
            case "Steps":
            switch (AggregateOperator)
            {
              case "Sum":
                return items => items.Sum(x => x.Steps);
              ...
            }
          }
        }
      }
    }

    public class PortfolioProjection : SqlProjection
    {
      public PortfolioProjection()
      {
        When<PortfolioAdded>(@event =>
          TSql.NonQueryStatement(
            "INSERT INTO [Portfolio] (Id, Name) VALUES (@P1, @P2)",
            new { P1 = TSql.Int(@event.Id), P2 = TSql.NVarChar(@event.Name, 40) }
        ));
        When<PortfolioRemoved>(@event =>
          TSql.NonQueryStatement(
            "DELETE FROM [Portfolio] WHERE Id = @P1",
            new { P1 = TSql.Int(@event.Id) }
        ));
        When<PortfolioRenamed>(@event =>
          TSql.NonQueryStatement(
            "UPDATE [Portfolio] SET Name = @P2 WHERE Id = @P1",
            new { P1 = TSql.Int(@event.Id), P2 = TSql.NVarChar(@event.Name, 40) }
        ));
      }
    }

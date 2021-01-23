    .AddColumns(cols => {
         cols.Add("opportunityid").WithVisibility(false)
             .WithFiltering(true)      // MUST have filtering enabled on column definion, otherwise it will not appear in QueryOptions
             .WithValueExpression(i => i.OpportunityID);
         cols.Add("Cluster").WithHeaderText("Cluster")
             .WithFiltering(true)
             .WithVisibility(false)
             .WithAllowChangeVisibility(true)
             .WithValueExpression(i => i.Cluster);

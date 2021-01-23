    MVCGridDefinitionTable.Add("Filtered", new MVCGridBuilder<SourcedPartner>()
          .AddColumns(....)
          .WithSorting(true, "MySortedColumnName")
          .WithFiltering(true) // This lets the GridContext know that something will populate QueryOptions.Filters section
          .WithRetrieveDataMethod((context) => 
              {
                 var options = context.QueryOptions;
                 string opID = options.GetFilterString("opprtunityid");
                 string cluster = options.GetFilterString("Cluster");
                 .......
                });
           

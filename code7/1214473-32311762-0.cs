     var idParam = new SqlParameter {
         ParameterName = "id",
          Value = 1};
     var votesParam = new SqlParameter {
          ParameterName = "voteCount",
          Value = 0,
          Direction = ParameterDirection.Output };
     var results = context.Database.SqlQuery<Person>(
         "GetPersonAndVoteCount @id, @voteCount out",
          idParam,
          votesParam);
     var person = results.Single();//This line is important
     var votes = (int)votesParam.Value;

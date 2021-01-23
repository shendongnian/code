    var actualFinishParameter = new SqlParameter("@actualFinish", SqlDbType.DateTime);
    Object actualFinish = DBNull.Value;
    DateTime finishDate;
    if(DateTime.TryParse(sortedCells[i].finishedDate, out finishDate))
        actualFinish = finishDate;
    actualFinishParameter.Value = actualFinish;
    command.Parameters.Add(actualFinishParameter);

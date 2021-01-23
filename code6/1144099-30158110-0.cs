    // Get unique question info.
    var questions = list
        .GroupBy(x => x.QuestionID)
        .Select(x => new { Id = x.Key, Title = x.First().Question });
    // Set up the columns for the data table as a "pivot table" with columns per question.
    DataTable myTable = new DataTable("QuestionsPivotTable");
    var fixedColumns = new [] { 
        new DataColumn("Member ID", typeof(string)),
        new DataColumn("User Name", typeof(string)),
    };
    var questionColumns = questions.Select(x => new DataColumn(x.Title, typeof(string)));
    myTable.Columns.AddRange(fixedColumns.Concat(questionColumns).ToArray());

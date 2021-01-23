    var results = GetStudentPassingRatio();
    var passingCounts = from result in results
        group result by result.ClassName into classResults
        select new /* some object type */
        {
            ClassName = classResults.Key,
            PassCount = classResults.Count(x => x.Percentage > 40)
        };

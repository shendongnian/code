    var query = from center in behzad.Customer_Care_Database_Analysis_Centers
        join details in behzad.Customer_Care_Database_Analysis_DETAILs
           on center.code_markaz equals details.code_markaz
        where details.fileid == FILE_ID
        where details.Any()
        select new { Name = center.name_markaz, Count = details.Count()};
    
    foreach(var point in query)
    {
        series1.Points.Add(new SeriesPoint(point.Name, new double[] { point.Count };
        counter += 15;
    }

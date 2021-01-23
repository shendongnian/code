    foreach (var connection in book.Connections.Cast<WorkbookConnection>()
        .Where(c => c.Type == XlConnectionType.xlConnectionTypeOLEDB))
    {
        var conString = connection.OLEDBConnection.Connection.ToString();
        if (conString.Contains("Initial Catalog") && conString.Contains("Data Source"))
            connection.OLEDBConnection.Connection = conString.Replace(ExlCubeServer,
                Settings.Default.OLAPServer[1]);
    }

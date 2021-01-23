     book.Connections.ToList().Where(c => c.Type == XlConnectionType.xlConnectionTypeOLEDB).ToList().ForEach(connection => PerformAction(connection));
        
        public static void PerformAction(WorkbookConnection connection)
        {
        	var conString = connection.OLEDBConnection.Connection.ToString();
        
        	if (conString.Contains("Initial Catalog") && conString.Contains("Data Source"))
        		connection.OLEDBConnection.Connection = conString.Replace(ExlCubeServer,
        			Settings.Default.OLAPServer[1]);
        }

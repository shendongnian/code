    public class MySqlDataReaderWrapper:
        Microsoft.ReportingServices.DataProcessing.IDataReader
        {
          private System.Data.IDataReader sourceDataReader;
          public MySqlDataReaderWrapper(System.Data.IDataReader dataReader)
          {
            this.sourceDataReader = dataReader.
          }
        // Implementation of methods of Microsoft.ReportingServices.DataProcessing.IDataReader
        }

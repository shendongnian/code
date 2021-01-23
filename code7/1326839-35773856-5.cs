	public interface IDataRowConvertible
	{
		void DefineColumns(DataColumnCollection columns);
		void WriteToRow(DataRow row);
	}

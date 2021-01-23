	public interface IDataRowConvertible
	{
	}
	public class CameraSettings : IDataRowConvertible
	{
	}
    public static DataTable ConvertListToDataTable<T>(IEnumerable<T> list) where T : IDataRowConvertible
    {
		// Do something
    }

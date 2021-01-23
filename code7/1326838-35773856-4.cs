	public interface IDataRowConvertible
	{
	}
	public class CameraSettings : IDataRowConvertible
	{
	}
    public static DataTable ConvertListToDataTable(IEnumerable<IDataRowConvertible> list){
		// Do something
    }

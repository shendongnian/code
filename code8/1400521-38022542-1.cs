    public interface DataRowConvertable
    {
    	DataRow GetDataRow();
    }
    
    public class SomeClass : DataRowConvertable
    {
    	public SomeClass() { }
    	public SomeClass(string name, string address, string phone)
    	{
    		Name = name;
    		Address = address;
    		Phone = phone;
    	}
    
    	public string Name { get; set; }
    	public string Address { get; set; }
    	public string Phone { get; set; }
    
    	public DataRow GetDataRow()
    	{
    		DataRow row = GetDataTable().NewRow();
    		row["Name"] = this.Name;
    		row["Address"] = this.Address;
    		row["Phone"] = this.Phone;
    		return row;
    	}
    
    	public static DataTable GetDataTable()
    	{
    		DataTable table = new DataTable("SomeClassTable");
    		table.Columns.Add("Name", typeof(string));
    		table.Columns.Add("Address", typeof(string));
    		table.Columns.Add("Phone", typeof(string));
    		return table;
    	}
    }

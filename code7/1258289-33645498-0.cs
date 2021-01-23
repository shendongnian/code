    public abstract class VehicleHandler
    {
        public abstract void SetVehicles(object listOfVehicles);
        public abstract DataTable DataTable { get; }
    }
    public class VehicleHandler<T> : VehicleHandler
    {
        List<T> vehicles;
        public override void SetVehicles (object listOfVehicles)
        {
            this.vehicles = (List<T>) listOfVehicles;
        }
        public override DataTable DataTable => CreateDataTable(vehicles);
        public DataTable CreateDataTable(IEnumerable<T> list)
        {
            Type type = typeof (T);
            var properties = type.GetProperties();
            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name,
                    Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }
            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }

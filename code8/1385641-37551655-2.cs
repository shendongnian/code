    public abstract class ProviderBase
    {
        public abstract Employee[] GetAllEmployees();
    }
    public class MySqlProvider:ProviderBase
    {
        public override Employee[] GetAllEmployees()
        {
            string select = "select * from employees";
            //query from mysql ...
        }
    }
    public class MsSqlProvider : ProviderBase
    {
        public override Employee[] GetAllEmployees()
        {
            string select = "select * from user u left join employee_record e on u.id=e.id";
            //query from mysql ...
        }
    }

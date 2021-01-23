      private void button1_Click(object sender, EventArgs e)
        {
            List<Employees> employees = new List<Employees>();
            Employees employee = new Employees();
            employee.firstName = "a";
            employees.Add(employee);
            string json = JsonConvert.SerializeObject(employees);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        }
        
    }
    public class Employees
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

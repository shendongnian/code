    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<Person> people = new List<Person>() {
                    new Person() { BirthDate = DateTime.Parse("10/04/1950"), ID = 1, Name = "Richard"},
                    new Person() { BirthDate = DateTime.Parse("10/04/1950"), ID = 2, Name = "Dan"},
                    new Person() { BirthDate = DateTime.Parse("10/04/1950"), ID = 3, Name = "John"},
                    new Person() { BirthDate = DateTime.Parse("12/16/1950"), ID = 4, Name = "Jane"},
                    new Person() { BirthDate = DateTime.Parse("12/16/1940"), ID = 5, Name = "Ron"}
                };
                Dictionary<DateTime, List<Person>> dict = people.AsEnumerable()
                    .GroupBy(x => x.BirthDate, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                DataTable dt = new DataTable();
                dt.Columns.Add("BirthDate", typeof(DateTime));
                dt.Columns.Add("Name", typeof(string));
                foreach (Person person in dict[DateTime.Parse("10/04/1950")])
                {
                    dt.Rows.Add(new object[] { person.BirthDate, person.Name });
                }
                dataGridView1.DataSource = dt;
            }
        }
        public class Person
        {
            public int ID { get;set;}
            public string Name { get;set;}
            public DateTime BirthDate { get;set;}
        }
    }
    ​

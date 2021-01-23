    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace Write_to_database
    {
        public partial class WriteToDatabase : Form
        {
            public WriteToDatabase()
            {
                InitializeComponent();
            }
        private void bWrite_Click(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            WriteToOutput("test");
            WriteToOutput(sql.OpenSqlConnection());
            WriteToOutput(sql.WriteToTraining("20151231", "10", 10.0, 5, 5));
            WriteToOutput(sql.CloseSqlConnection());
        }
        public string WriteToOutput(string output)
        {
            this.tOutput.Text += output + "\r\n";
        }
    }
    public class SqlServer
    {
        SqlConnection con = new SqlConnection("Data Source=WINSERVER;Initial Catalog=TRAINING;Integrated Security=SSPI;");
        public string OpenSqlConnection()
        {
            try
            {
                con.Open();
                return "Connection to: " + "'Data Source=WINSERVER;Initial Catalog=TRAINING;Integrated Security=SSPI;'" + " successful.";
            }
            catch
            {
                 return "Connection to: " + "'Data Source=WINSERVER;Initial Catalog=TRAINING;Integrated Security=SSPI;'" + " failed.";
            }
        }
        public string CloseSqlConnection()
        {
            try
            {
                con.Close();
                return "Connection to: " + "'Data Source=WINSERVER;Initial Catalog=TRAINING;Integrated Security=SSPI;'" + " successfully closed";
            }
            catch
            {
                return "Connection to: " + "'Data Source=WINSERVER;Initial Catalog=TRAINING;Integrated Security=SSPI;'" + " not closed.";
            }
        }
        public string WriteToTraining(string date, string lift, double weight, int reps, int week)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO LIFT_HISTORY VALUES(@date,@lift,@weight,@reps,@week)", con))
                {
                    command.Parameters.Add(new SqlParameter("weight", weight.ToString()));
                    command.Parameters.Add(new SqlParameter("date", date.ToString()));
                    command.Parameters.Add(new SqlParameter("week", week.ToString()));
                    command.Parameters.Add(new SqlParameter("reps", date.ToString()));
                    command.Parameters.Add(new SqlParameter("lift", date.ToString()));
                    command.ExecuteNonQuery();
                }
                return "Data successfully written to database.";
            }
            catch
            {
                return "Data not written to database.";
            }
        }
    }
}

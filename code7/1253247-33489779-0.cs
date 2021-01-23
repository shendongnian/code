    using System.Threading.Tasks;
.
    protected void Button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                       SqlConnection conn = new SqlConnection("Data Source=MATT\\RICHARDSON2008R2;Initial Catalog=Minerva;User ID=User;Password=password; Asynchronous Processing=True");
                       SqlCommand cmd = new SqlCommand("exec UpdateRandomData '" + UpdateID.Text + "'",conn);
                       conn.Open();
                       cmd.ExecuteNonQuery();
                       conn.Close();
                  })
        }

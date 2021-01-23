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
        using System.Data.Sql;
            public void proName(string str)
            {
                SqlDataReader reader;
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    string proId = textBox3.Text;
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("SELECT proName FROM products where proId = proId;", sqlcon);
                    sqlcmd.CommandType = CommandType.Text;
                    reader = sqlcmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Response.Write(reader[0].ToString());
        
                    }
        
                }
            }

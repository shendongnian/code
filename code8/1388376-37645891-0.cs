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
        
        namespace LoginForm
        {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        
        
                private void button2_Click(object sender, EventArgs e)
                {
                    
        
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\carme\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;"))
                    {
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Login where Username = @userName and Password = @passWord, con))
                        {
                           sda.SelectCommand.Parameters.AddWithValue("@userName", textBox1.Text);
                           sda.SelectCommand.Parameters.AddWithValue("@passWord", textBox2.Text);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
        
                            if (dt.Rows[0][0].ToString() == "1")
                            {
                                this.Hide();
                                Main ss = new Main();
                                ss.Show();
                            }
                            else
                            {
                                MessageBox.Show("Check your username and password");
                            }
                        }
                    }
        
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    this.Close();
                }
        
        }
        }

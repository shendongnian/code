    SqlConnection con = new SqlConnection("Data Source");
                DataSet dsa = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select where BayNumber='" + comboBox1.Text.Trim() + "';", con);
                da.Fill(dsa);
    
    
                for (int i = 0; i <= 8; i++)
                {
                    for (int k = 0; k <= 8; k++)
                    {
    
    
                        textBox1.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label2.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                        textBox2.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label4.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                        textBox3.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label6.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                        textBox4.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label8.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                        textBox5.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label10.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                        textBox6.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label12.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                        textBox7.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label14.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                        textBox8.Text = dsa.Tables[0].Rows[i++]["PatientId"].ToString();
                        label16.Text = dsa.Tables[0].Rows[k++]["Status"].ToString();
                    }
                }

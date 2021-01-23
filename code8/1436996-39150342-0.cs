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
    
    namespace dyna
    {
        public partial class Form1 : Form
        {
            public static string var = "";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6056TSF;Initial Catalog=LibararyManagement;Integrated Security=True");
            Form2 f2 = new Form2();
           
            public Form1()
            {
                InitializeComponent();
    
            
               
    
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Attribute where Test_Id like '"+Form2.a+"' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
    
                
                var arr = new Label[dt.Rows.Count];
    
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var lab = new Label();
    
                  
                        lab.Text = dt.Rows[i][1].ToString();
                    
                    // Other properties sets for tbox
    
                    this.panel1.Controls.Add(lab);
    
                    arr[i] = lab;
                    lab.Location = new Point(32, 32 + (i * 32));
                    lab.Width = 62;
                }
    
                textbox();
            }
            void textbox()
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Attribute Where Test_Id like '"+Form2.a+"' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                var arr = new TextBox[dt.Rows.Count];
    
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var texbox = new TextBox();
    
    
                    //teexbox.Text = dt.Rows[i][0].ToString();
    
                    // Other properties sets for tbox
    
                    this.panel1.Controls.Add(texbox);
    
                    arr[i] = texbox;
                    texbox.Location = new Point(122,32 + (i * 32));
                   
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
    
                foreach (TextBox text in panel1.Controls.OfType<TextBox>())
                {
                    listBox2.Items.Add(text.Text);
    
                }
    
    
                foreach (Label lbl in panel1.Controls.OfType<Label>())
                {
                    listBox1.Items.Add(lbl.Text);
    
    
                }
    
    
                con.Open();
                    String query = "INSERT INTO Reg_Test_Atrribute (RTA_Name,RTA_Value,TR_Id) VALUES(@RTA_Name,@RTA_Value,@TR_Id)";
    
                    SqlCommand command = new SqlCommand(query,con);
                    command.Parameters.Add(new SqlParameter("@RTA_Name", SqlDbType.VarChar));
                    foreach (var b in listBox2.Items)
                    {
    
                        command.Parameters["@RTA_Name"].Value = b.ToString();
                    }
                    command.Parameters.Add(new SqlParameter("RTA_Value", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@TR_Id", SqlDbType.VarChar));
                    foreach (var a in listBox1.Items)
                    {
                        command.Parameters["RTA_Value"].Value = a.ToString();
                        command.Parameters["@TR_Id"].Value = Form2.a.ToString();
                        command.ExecuteNonQuery();
                        }
                    con.Close();
                    /*con.Open();
                    string saveStaff = "INSERT into Reg_Test_Atrribute(RTA_Name, RTA_Value , TR_Id ) " +
                           " VALUES ('" + message + "', '" + msg + "' ,'" + Form2.a + "');";
                    SqlCommand cmd = new SqlCommand(saveStaff, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sucessfully Saved");
                    */
    
                }
            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }
    
                }
    
            }
    
    
                
            
        

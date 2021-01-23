    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Windows.Forms;
    using System.Data;
    namespace APMC
    {
         
        class Action_Btn
         {
           
            public void Navigation_Btns(String Con_Str, String Tab_Name, Control form, String Btn_Name,int ID)
            {
                int i = ID;
                List<Control> TB_List = new List<Control>();
                
                foreach (Control childcontrol in form.Controls)
                {
                    if (childcontrol is GroupBox)
                    {
                        foreach (Control cc in childcontrol.Controls)
                        {
                         
                            if (cc is TextBox)
                            {
                                TB_List.Add(cc); 
                                                      
                            }
                        }
                    }
                }
                using (SqlConnection con = new SqlConnection(Con_Str))
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from " + Tab_Name + "", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, Tab_Name);
                    if (Btn_Name == "CmdFirst")
                    {
                        if (ds.Tables[Tab_Name].Rows.Count > 0)
                        {
                            i = 0;
                            foreach (Control Txt_Name in TB_List)
                            {
                                String field_name = Txt_Name.Name.Substring(3);
                                Txt_Name.Text = ds.Tables[Tab_Name].Rows[i][field_name].ToString();
                            }
                        }
                        if (i == 0 )
                        {
                            MessageBox.Show("This is First Record");
                        }
                    }
                    if (Btn_Name == "CmdNext")
                    {
                                      
                        if (i < ds.Tables[Tab_Name].Rows.Count )
                        {
                        
                       
                            foreach (Control Txt_Name in TB_List)
                            {
                                String field_name = Txt_Name.Name.Substring(3);
                                                    
                              Txt_Name.Text = ds.Tables[Tab_Name].Rows[i][field_name].ToString();
                            }
                                
                              }
                        if (i == ds.Tables[Tab_Name].Rows.Count)
                        {
                            MessageBox.Show("This is Last Record");
                        }
                 
                      
                    }
                    if (Btn_Name == "CmdPrev")
                    {
                        if (i == ds.Tables[Tab_Name].Rows.Count || i != 1)
                        {
                            i = i - 2;
                            foreach (Control Txt_Name in TB_List)
                            {
                                String field_name = Txt_Name.Name.Substring(3);
                                Txt_Name.Text = ds.Tables[Tab_Name].Rows[i][field_name].ToString();
                            }
                        }
                        if (i == 0)
                        {
                            MessageBox.Show("This is First Record");
                        }
                    }
                    if (Btn_Name == "CmdLast")
                    {
                        if (ds.Tables[Tab_Name].Rows.Count - 1 >= i)
                        {
                            i = ds.Tables[Tab_Name].Rows.Count - 1;
                            foreach (Control Txt_Name in TB_List)
                            {
                                String field_name = Txt_Name.Name.Substring(3);
                                Txt_Name.Text = ds.Tables[Tab_Name].Rows[i][field_name].ToString();
                            }
                        }
                        if (i == ds.Tables[Tab_Name].Rows.Count)
                        {
                            MessageBox.Show("This is Last Record");
                        }
                    }
                }
            }
        }
    }
       
        
        
        

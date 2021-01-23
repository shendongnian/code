    public partial class UpComing : System.Web.UI.Page
            String sel = "SELECT Cmpny_Data.C_Name, Cmpny_Data.J_location, Cmpny_Data.Copm_desc, Cmpny_Data.J_Crtra, Cmpny_Data.Cmps_Date, Cmpny_Data.Last_date, Cmpny_Data.Elg_cTRTA FROM Cmpny_Data INNER JOIN Details ON Cmpny_Data.Elg_cTRTA < Details.cpi WHERE (Details.En_no='" + Session["uname"].ToString() + "') AND (Cmpny_Data.Last_date > SYSDATETIME()) ";
            cmd2 = new SqlCommand(sel, obj.con);
            dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                C_N.Text += dr[0].ToString() + '`';
                C_P.Text += dr[2].ToString() + '`';
                J_C.Text += dr[3].ToString() + '`';
                J_L.Text += dr[1].ToString() + '`';
                E_C.Text += dr[6].ToString() + '`';
                C_D.Text += dr[4].ToString() + '`';
                L_D.Text += dr[5].ToString() + '`';
            }
            dr.Dispose();
            cmd2.Dispose();
            obj.con.Close();
            String AllCN = C_N.Text;
            String AllCP = C_P.Text;
            String AllJC = J_C.Text;
            String AllJL = J_L.Text;
            String AllEC = E_C.Text;
            String AllCD = C_D.Text;
            String AllLD = L_D.Text;
            char separator = '`';
            String[] CNs = AllCN.Split(separator);
            String[] CPs = AllCP.Split(separator);
            String[] JCs = AllJC.Split(separator);
            String[] JLs = AllJL.Split(separator);
            String[] ECs = AllEC.Split(separator);
            String[] CDs = AllCD.Split(separator);
            String[] LDs = AllLD.Split(separator);
            C_N.Text = null;
            C_P.Text = null;
            J_C.Text = null;
            J_L.Text = null;
            E_C.Text = null;
            C_D.Text = null;
            L_D.Text = null;
            for (int i = 0; i < ttlq; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < 1; j++)
                {
                    TableCell cell1 = new TableCell();
                    cell1.Width = 100;
                    cell1.HorizontalAlign = HorizontalAlign.Left;
                    Label label1 = new Label();
                    label1.ID = "Lable1";
                    label1.Text = " Company Name :  ";
                    cell1.Controls.Add(label1);
                    row.Cells.Add(cell1);
                    TableCell cell2 = new TableCell();
                    cell2.Width = 650;
                    cell2.HorizontalAlign = HorizontalAlign.Left;
                    Label C_Name = new Label();
                    C_Name.Width = 650;
                    C_Name.Height = 20;
                    C_Name.ID = "Cmp_Name";
                    C_Name.Text = CNs[i];
                    cell2.Controls.Add(C_Name);
                    row.Cells.Add(cell2);
                }
                table1.Rows.Add(row);
                TableRow row1 = new TableRow();
                for (int k = 0; k < 1; k++)
                {
                    TableCell cell3 = new TableCell();
                    cell3.Width = 100;
                    cell3.HorizontalAlign = HorizontalAlign.Left;
                    Label label2 = new Label();
                    label2.ID = "Lable2";
                    label2.Text = " Company Profile :  ";
                    cell3.Controls.Add(label2);
                    row1.Cells.Add(cell3);
                    TableCell cell4 = new TableCell();
                    cell4.Width = 650;
                    cell4.HorizontalAlign = HorizontalAlign.Left;
                    Label C_Prof = new Label();
                    C_Prof.Width = 650;
                    C_Prof.Height = 10;
                    C_Prof.ID = "Cmp_Prf";
                    C_Prof.Text = CPs[i];
                    cell4.Controls.Add(C_Prof);
                    row1.Cells.Add(cell4);
                }
                table1.Rows.Add(row1);
                TableRow row2 = new TableRow();
                for (int k = 0; k < 1; k++)
                {
                    TableCell cell5 = new TableCell();
                    cell5.Width = 100;
                    cell5.HorizontalAlign = HorizontalAlign.Left;
                    Label label3 = new Label();
                    label3.ID = "Lable3";
                    label3.Text = " Company Profile :  ";
                    cell5.Controls.Add(label3);
                    row2.Cells.Add(cell5);
                    TableCell cell6 = new TableCell();
                    cell6.Width = 650;
                    cell6.HorizontalAlign = HorizontalAlign.Left;
                    Label J_Crit = new Label();
                    J_Crit.Width = 650;
                    J_Crit.Height = 10;
                    J_Crit.ID = "Job_Crit";
                    J_Crit.Text = JCs[i];
                    cell6.Controls.Add(J_Crit);
                    row2.Cells.Add(cell6);
                }
                table1.Rows.Add(row2);
                TableRow row3 = new TableRow();
                for (int k = 0; k < 1; k++)
                {
                    TableCell cell7 = new TableCell();
                    cell7.Width = 100;
                    cell7.HorizontalAlign = HorizontalAlign.Left;
                    Label label4 = new Label();
                    label4.ID = "Lable4";
                    label4.Text = " Job Location :  ";
                    cell7.Controls.Add(label4);
                    row3.Cells.Add(cell7);
                    TableCell cell8 = new TableCell();
                    cell8.Width = 650;
                    cell8.HorizontalAlign = HorizontalAlign.Left;
                    Label J_Loc = new Label();
                    J_Loc.Width = 650;
                    J_Loc.Height = 10;
                    J_Loc.ID = "Job_Location";
                    J_Loc.Text = JLs[i];
                    cell8.Controls.Add(J_Loc);
                    row3.Cells.Add(cell8);
                }
                table1.Rows.Add(row3);
                TableRow row4 = new TableRow();
                for (int k = 0; k < 1; k++)
                {
                    TableCell cell9 = new TableCell();
                    cell9.Width = 100;
                    cell9.HorizontalAlign = HorizontalAlign.Left;
                    Label label5 = new Label();
                    label5.ID = "Lable5";
                    label5.Text = " Eligibility Criteria :  ";
                    cell9.Controls.Add(label5);
                    row4.Cells.Add(cell9);
                    TableCell cell10 = new TableCell();
                    cell10.Width = 650;
                    cell10.HorizontalAlign = HorizontalAlign.Left;
                    Label E_Crit = new Label();
                    E_Crit.Width = 650;
                    E_Crit.Height = 10;
                    E_Crit.ID = "Elg_Crit";
                    E_Crit.Text = ECs[i];
                    cell10.Controls.Add(E_Crit);
                    row4.Cells.Add(cell10);
                }
                table1.Rows.Add(row4);
                TableRow row5 = new TableRow();
                for (int k = 0; k < 1; k++)
                {
                    TableCell cell11 = new TableCell();
                    cell11.Width = 100;
                    cell11.HorizontalAlign = HorizontalAlign.Left;
                    Label label6 = new Label();
                    label6.ID = "Lable6";
                    label6.Text = " Campus Date :  ";
                    cell11.Controls.Add(label6);
                    row5.Cells.Add(cell11);
                    TableCell cell12 = new TableCell();
                    cell12.Width = 650;
                    cell12.HorizontalAlign = HorizontalAlign.Left;
                    Label C_Date = new Label();
                    C_Date.Width = 650;
                    C_Date.ID = "Camp_Date";
                    C_Date.Text = CDs[i];
                    cell12.Controls.Add(C_Date);
                    row5.Cells.Add(cell12);
                }
                table1.Rows.Add(row5);
                TableRow row7 = new TableRow();
                for (int k = 0; k < 1; k++)
                {
                    TableCell cell13 = new TableCell();
                    cell13.Width = 100;
                    cell13.HorizontalAlign = HorizontalAlign.Left;
                    Label label7 = new Label();
                    label7.ID = "Lable7";
                    label7.Text = " Last Date :  ";
                    cell13.Controls.Add(label7);
                    row7.Cells.Add(cell13);
                    TableCell cell14 = new TableCell();
                    cell14.Width = 650;
                    cell14.HorizontalAlign = HorizontalAlign.Left;
                    Label L_Date = new Label();
                    L_Date.Width = 650;
                    L_Date.ID = "Last_Date";
                    L_Date.Text = LDs[i];
                    cell14.Controls.Add(L_Date);
                    row7.Cells.Add(cell14);
                }
                table1.Rows.Add(row7);
                TableRow row8 = new TableRow();
                for (int k = 0; k < 1; k++)
                {
                    TableCell cell15 = new TableCell();
                    cell15.Width = 100;
                    cell15.HorizontalAlign = HorizontalAlign.Left;
                    Button Apply = new Button();
                    Apply.ID = "Apply_Button";
                    Apply.Text = "Apply";
                    Apply.Width = 50;
                    Apply.Height = 20;
                    Apply.Visible = true;
                    Apply.ViewStateMode = System.Web.UI.ViewStateMode.Inherit;
                    Apply.UseSubmitBehavior = true;
                    Apply.CausesValidation = true;
                    Apply.ClientIDMode = System.Web.UI.ClientIDMode.Inherit;
                    Apply.EnableTheming = true;
                    Apply.CausesValidation = true;
                    Apply.Enabled = true;
                    Apply.Click += Apply_Click;
                    cell15.Controls.Add(Apply);
                    row8.Cells.Add(cell15);
                    TableCell cell16 = new TableCell(); ;
                    cell16.Width = 100;
                    cell16.HorizontalAlign = HorizontalAlign.Left;
                    Label Alert = new Label();
                    //Alert.Text = dr1.ToString();
                    Alert.Text = "You have applied for this campus. If you are not interested for this campus, please contact T&P Cell.";
                    Alert.Font.Bold = true;
                    cell16.Controls.Add(Alert);
                    row8.Cells.Add(cell16);
                    openConn conn = new openConn();
                    conn.checkdb();
                    String sel3 = "Select * from  Student_Company where [Enrollment]='" + Session["uname"].ToString() + "' and ([Cmpny_Name]='" + CNs[i] + "')";
                    cmd3 = new SqlCommand(sel3, conn.con);
                    dr1 = cmd3.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        Alert.Visible = true;
                        Apply.Visible = false;
                        dr1.Dispose();
                        cmd3.Dispose();
                        conn.con.Close();
                    }
                    else
                    {
                        Alert.Visible = false;
                        Apply.Visible = true;
                    }
                }
                table1.Rows.Add(row8);
                //table1.BorderWidth = 1;
            }
        }
    }
    protected void Apply_Click(object sender, EventArgs e)
    {
        openConn obj = new openConn();
        obj.checkdb();
        cmd4 = new SqlCommand("Insert into Student_Company Values('" + Session["uname"].ToString() + "', '" + C_Name.Text + "')", obj.con);
        cmd4.ExecuteNonQuery();
        cmd4.Dispose();
        obj.con.Close();
    }
}

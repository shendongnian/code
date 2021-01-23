        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        using System.Data.SqlClient;
        using Excel = Microsoft.Office.Interop.Excel; 
        namespace WindowsFormsApplication8
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
                private void button1_Click(object sender, EventArgs e)
                {
                    SqlConnection cnn;
                    string connectionString = null;
                    string data = null;
                    int i = 0;
                    int j = 0;
                    int h = 1;
                    int Appeal_ID = 20;
                    object misValue = System.Reflection.Missing.Value;
                    label1.Text = "Processing......";
                    connectionString = "data source=D7010-H14NBZ1\\SQLEXPRESS;initial catalog=itest;user id=xxxx;password=xxxx;";
                    StringBuilder query = new StringBuilder();
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    Excel.Application oXL;
                    Excel._Workbook oWB;
                    Excel._Worksheet oSheet;
                    oXL = new Excel.Application();
                    oWB = (Excel._Workbook)(oXL.Workbooks.Add(misValue));
                    oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                    for (h = 48; h >= 1; h--)
                    {
                        query.Append("SELECT     TOP (100) PERCENT dbo.FDN_GivingAppeal_Main.Appeal_ID, dbo.FDN_GivingAppeal_Main.ID, dbo.FDN_GivingAppeal_Main.Appeal, 				dbo.vBoCsContact.MemberType, ");
                        query.Append("dbo.vBoCsContact.Title, dbo.vBoCsContact.Prefix, dbo.vBoCsContact.FirstName, dbo.vBoCsContact.MiddleName AS MI, dbo.vBoCsContact.LastName, ");
                        query.Append("dbo.vBoCsContact.Suffix, dbo.vBoCsContact.Designation, dbo.vBoCsContact.Informal, dbo.vBoCsContact.Email, dbo.vBoCsContact.Company, ");
                        query.Append("dbo.vBoCsAddress.Address1, dbo.vBoCsAddress.Address2, dbo.vBoCsAddress.City, dbo.vBoCsAddress.StateProvince, dbo.vBoCsAddress.Zip, ");
                        query.Append("dbo.vBoCsAddress.Country, dbo.vBoCsAddress.Phone, dbo.FDN_GivingAppeal_Main.Amount AS YrTotal_LastGivingYr, 				dbo.FDN_GivingAppeal_Main.LastTransDate, ");
                        query.Append("dbo.FDN_GivingAppeal_Main.LastTransAmt, dbo.FDN_GivingAppeal_Main.LargestGiving, dbo.FDN_GivingAppeal_Main.LifetimeTotal, ");
                        query.Append("dbo.FDN_GivingAppeal_Main.FiscalYear AS LastGivingYr, dbo.FDN_GivingAppeal_Main.CapitalCampaign, dbo.FDN_GivingAppeal_Main.P2GScore, ");
                        query.Append("dbo.FDN_GivingAppeal_Main.InnerCircle ");
                        query.Append("FROM         dbo.FDN_GivingAppeal_Main INNER JOIN ");
                        query.Append("dbo.FDN_AppealCode_Sort ON dbo.FDN_GivingAppeal_Main.Appeal_ID = dbo.FDN_AppealCode_Sort.ID AND  ");
                        query.Append("dbo.FDN_GivingAppeal_Main.Appeal = dbo.FDN_AppealCode_Sort.Appeal_code INNER JOIN  ");
                        query.Append("dbo.vBoCsContact ON dbo.FDN_GivingAppeal_Main.ID = dbo.vBoCsContact.ID INNER JOIN ");
                        query.Append("dbo.vBoCsAddress ON dbo.vBoCsContact.ID = dbo.vBoCsAddress.ID ");
                        query.Append("WHERE    (dbo.vBoCsAddress.PreferredMail = 1) AND (dbo.vBoCsAddress.BadAddress <> 'BAD') AND  (dbo.FDN_GivingAppeal_Main.Appeal_ID = " + 				Appeal_ID + ") AND   Appeal_Sort in(" + h + ") ");
                        query.Append("ORDER BY dbo.FDN_AppealCode_Sort.Appeal_Sort desc, dbo.vBoCsContact.LastName, dbo.vBoCsContact.FirstName; ");
                        SqlDataAdapter dscmd = new SqlDataAdapter(query.ToString(), cnn);
                        DataTable dt = new DataTable();
                        dscmd.Fill(dt);
                        query.Clear();
                        try
                        {
                            oSheet = (Excel._Worksheet)oXL.Worksheets.Add();
                            oSheet.Name = dt.Rows[0]["Appeal"].ToString().Replace(" ", "").
                                Replace("  ", "").Replace("/", "").
                                    Replace("\\", "").Replace("*", "");
                            for (i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                for (j = 0; j <= dt.Columns.Count - 1; j++)
                                {
                                    data = dt.Rows[i].ItemArray[j].ToString();
                                    oSheet.Cells[i + 1, j + 1] = data;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            GC.Collect();
                        }
                    }
                    oWB.SaveAs(@"H:\4862appeals1.xlsx",
                       AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                    oWB.Close(true, misValue, misValue);
                    oXL.Quit();
                    label1.Text = "Click button to start";     
                }
            }
        }

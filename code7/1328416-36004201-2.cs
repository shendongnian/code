    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication1
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //Table 1
                DataTable table1 = new DataTable();
                table1.Columns.Add("emp_num(key)", typeof(Int32));
                table1.Columns.Add("salary", typeof(float));
                table1.Columns.Add("ov", typeof(float));
                table1.Rows.Add(455, 3000, 67.56);
                table1.Rows.Add(456, 4000, 77.56);
                table1.Rows.Add(457, 6000, 87.56);
                grdTable1.DataSource = table1;
                grdTable1.DataBind();
                //Table 2
                DataTable table2 = new DataTable();
                table2.Columns.Add("emp_num(key)", typeof(Int32));
                table2.Columns.Add("salary", typeof(float));
                table2.Columns.Add("ov", typeof(float));
                table2.Rows.Add(455, 3000, 67.56);
                table2.Rows.Add(456, 4000, 27.56);
                table2.Rows.Add(457, 5000, 87.56);
                grdTable2.DataSource = table2;
                grdTable2.DataBind();
                //Compare
                DataTable result = new DataTable();
                result.Columns.Add("emp_num(key)", typeof(Int32));
                result.Columns.Add("salary_Table1", typeof(float));
                result.Columns.Add("salary_Table2", typeof(float));
                result.Columns.Add("same_Salary", typeof(string));
                result.Columns.Add("ov_Table1", typeof(float));
                result.Columns.Add("ov_Table2", typeof(float));
                result.Columns.Add("Same_OV", typeof(string));
                foreach (DataRow t1r in table1.Rows)
                {
                    foreach (DataRow t2r in table2.Rows)
                    {
                        var array1 = t1r.ItemArray;
                        var array2 = t2r.ItemArray;
                        //Check ID Column to decide if compare needs to be done 
                        if (array1[0].ToString() == array2[0].ToString())
                        {
                            if (array1.SequenceEqual(array2))
                            {
                                break;
                            }
                            else
                            {
                                int SalSame = 0;
                                int OvSame = 0;
                                if (array1[1].ToString() == array2[1].ToString())
                                {
                                    SalSame = 1;
                                }
                                if (array1[2].ToString() == array2[2].ToString())
                                {
                                    OvSame = 1;
                                }
                                result.Rows.Add(array1[0].ToString(), array1[1].ToString(), array2[1].ToString(), SalSame, array1[2].ToString(), array2[2].ToString(), OvSame);
                            }
                        }
                    }
                }
                grdresult.DataSource = result;
                grdresult.DataBind();
            }
        }
    }
    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <h3>First Table </h3>
                <asp:GridView runat="server" ID="grdTable1"></asp:GridView>
                <h3>Second Table </h3>
                <asp:GridView runat="server" ID="grdTable2"></asp:GridView>
                <h3>Result Table </h3>
                <asp:GridView runat="server" ID="grdresult"></asp:GridView>
            </div>
        </form>
    </body>
    </html>

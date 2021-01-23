            using ClosedXML.Excel;
            using System;
            using System.Collections.Generic;
            using System.Data;
            using System.Drawing;
            using System.IO;
            using System.Linq;
            using System.Web;
            using System.Web.UI;
            using System.Web.UI.WebControls;
       namespace ExportExcel
        {
        public partial class Index : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetData();
            }
        }
        private void GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)), new DataColumn("Name", typeof(string)), new DataColumn("Country", typeof(string)) });
            dt.Rows.Add(1, "abc", "UK");
            dt.Rows.Add(2, "def", "India");
            dt.Rows.Add(3, "ghi", "France");
            dt.Rows.Add(4, "jkl", "Russia");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("GridView_Data");
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    dt.Columns.Add(cell.Text);
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtNameRow = (TextBox)row.FindControl("txtName");
                    Label lblCountryRow = (Label)row.FindControl("lblCountry");
                    
                    DataRow drow = dt.NewRow();
                    for (int i = 0; i < GridView1.Columns.Count; i++)
                    {
                        drow[i] = row.Cells[i].Text;
                    }
                    drow["Name"] = txtNameRow.Text;
                    drow["Country"] = lblCountryRow.Text;
                    dt.Rows.Add(drow);
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=GV.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
           
    }
    }

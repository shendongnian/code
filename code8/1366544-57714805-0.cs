    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    namespace ReadData
    {
    public partial class ImportExelDataInGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Coneection String by default empty
            string ConStr = "";
            //Extantion of the file upload control saving into ext because 
            //there are two types of extation .xls and .xlsx of excel 
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            //getting the path of the file 
            string path = Server.MapPath("~/MyFolder/"+FileUpload1.FileName);
            //saving the file inside the MyFolder of the server
            FileUpload1.SaveAs(path);
            Label1.Text = FileUpload1.FileName + "\'s Data showing into the GridView";
            //checking that extantion is .xls or .xlsx
            if (ext.Trim() == ".xls")
            {
                //connection string for that file which extantion is .xls
                ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (ext.Trim() == ".xlsx")
            {
                //connection string for that file which extantion is .xlsx
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            //making query
            string query = "SELECT * FROM [Sheet1$]";
            //Providing connection
            OleDbConnection conn = new OleDbConnection(ConStr);
            //checking that connection state is closed or not if closed the 
            //open the connection
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //create command object
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // create a data adapter and get the data into dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            //fill the excel data to data set
            da.Fill(ds);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Columns[0].ToString() == "ID" && ds.Tables[0].Columns[1].ToString() == "name")
                    {
                    }
                    //else if (ds.Tables[0].Rows[0][i].ToString().ToUpper() == "NAME")
                    //{
                    //}
                    //else if (ds.Tables[0].Rows[0][i].ToString().ToUpper() == "EMAIL")
                    //{
                    //}
                }
            }
            //set data source of the grid view
            gvExcelFile.DataSource = ds.Tables[0];
            //binding the gridview
            gvExcelFile.DataBind();
            //close the connection
            conn.Close();
        }
    }
}

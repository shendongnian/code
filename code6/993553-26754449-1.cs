    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections;
    using System.Web.Script.Serialization;
    using System.Web.Helpers;
    using BL;
    using DAL;
    using Newtonsoft.Json;
    public partial class Project_Service : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        #region Testing
        [WebMethod]
        public static String GridValues()
        {
            String Qry = "SELECT [From Kgs] as From_Kg,[To kgs] as To_Kg,[1] as Zone1,[2] as Zone2,[3] as Zone3,[4] as Zone4,[5] as Zone5,[6] as Zone6,[7] as Zone7,[8] as Zone8,[9] as Zone9  FROM Tnt_Rate";
            DataTable dt = DbAccess.FetchDatatable(Qry);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            String Val = serializer.Serialize(rows);
            if (Val != "")
            {
                return (Val);
            }
            else
            {
                return "Error";
            }
        }
        [WebMethod]
        public static String Col_Datafeilds()
        {
            String Qry = "SELECT [From Kgs] as From_Kg,[To kgs] as To_Kg,[1] as Zone1,[2] as Zone2,[3] as Zone3,[4] as Zone4,[5] as Zone5,[6] as Zone6,[7] as Zone7,[8] as Zone8,[9] as Zone9  FROM Tnt_Rate";
            DataTable dt = DbAccess.FetchDatatable(Qry);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = new Dictionary<string, object>();
            String Col = "";
            int counter = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (counter < 2)
                {
                    row = new Dictionary<string, object>();
                    row.Add("name", col.ColumnName);
                    row.Add("type", "string");
                    rows.Add(row);
                }
                else if (counter >= 2)
                {
                    row = new Dictionary<string, object>();
                    row.Add("name", col.ColumnName);
                    row.Add("type", "number");
                    rows.Add(row);
                }
                counter += 1;
            }
            Col = serializer.Serialize(rows);
            //Col = JsonConvert.SerializeObject(rows);
            if (Col != "")
            {
                return (Col);
            }
            else
            {
                return "Error";
            }
        }
        [WebMethod]
        public static String Col_Columns()
        {
            String Qry = "SELECT [From Kgs] as From_Kg,[To kgs] as To_Kg,[1] as Zone1,[2] as Zone2,[3] as Zone3,[4] as Zone4,[5] as Zone5,[6] as Zone6,[7] as Zone7,[8] as Zone8,[9] as Zone9  FROM Tnt_Rate";
            DataTable dt = DbAccess.FetchDatatable(Qry);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            String Col = "";
            int counter = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (counter < 2)
                {
                    row = new Dictionary<string, object>();
                    row.Add("text", col.ColumnName.ToUpper());
                    row.Add("datafield", col.ColumnName);
                    row.Add("columntype", "textbox");
                    row.Add("width", "100");
                    row.Add("cellsalign", "left");
                    //row.Add("pinned", "true");
                    rows.Add(row);
                }
                else if (counter >= 2)
                {
                    row = new Dictionary<string, object>();
                    row.Add("text", col.ColumnName.ToUpper());
                    row.Add("datafield", col.ColumnName);
                    row.Add("columntype", "textbox");
                    row.Add("width", "25");
                    row.Add("cellsalign", "right");
                    rows.Add(row);
                }
            }
            Col = serializer.Serialize(rows);
           // Col = JsonConvert.SerializeObject(rows);
            if (Col != "")
            {
                return (Col);
            }
            else
            {
                return "Error";
            }
        }
    
        #endregion
    }

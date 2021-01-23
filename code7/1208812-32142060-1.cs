     $("#sellstuff").click(function () {
    
        var dataObject =
            { SubCategory: $("#scrolldummy").text() };
        
        $.getJSON("/OnlineStore/TotalNumberofSubCateg", dataObject, function (data) {
            $("#search").val(data + " Assorted Items for Sale.");
        });
    
    })
   
     [HttpGet]
        public JsonResult TotalNumberofSubCateg(string SubCategory)
        {
            int rowcount;
            string constr = ConfigurationManager.ConnectionStrings["StockConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
    
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DisplayCenterTab Where SubCategory = '"+ SubCategory.Replace("'","''") +"' ", con);
    
            cmd.CommandType = CommandType.Text;
            rowcount = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Json(rowcount, JsonRequestBehavior.AllowGet);
        }

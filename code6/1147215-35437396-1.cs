        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["CalendarUC"] != null && Request["CalendarUC"] == "Update")
            {
                var x = Request["x"];
                var y = Request["y"];
                //do stuff
                var ser = new JavaScriptSerializer().Serialize(new { result = true, message = "Hello" });
                Response.Clear();
                Response.ContentType = "application/json";
                Response.Write(ser);               
                Response.End();
            }
        }
    }

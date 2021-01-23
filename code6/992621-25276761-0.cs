            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=data.csv");
            Response.ContentType = "text/csv";
            Response.Write(stringContainingCSVData);
            Response.End();

            Byte[] fileBytes = pck.GetAsByteArray(); // convert excel data to bytes
    
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=\"fileName1.xlsx\"");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; 
            Response.AppendHeader("Content-Length", fileBytes.Length.ToString());
            Response.BinaryWrite(fileBytes);
            Response.End();

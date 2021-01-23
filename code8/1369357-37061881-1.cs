            // Send the merged PDF file to the user.
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            Response.ClearHeaders();
            response.ContentType = "application/pdf";
            response.AddHeader("Content-Disposition", "attachment; filename=1094C.pdf;");
            response.WriteFile(tempFileName);
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            DeleteFile(tempFileName); // Call right after flush but before close
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.

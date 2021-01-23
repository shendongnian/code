    string csv = jsonToCSV(content, ",");
    
                    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                    result.Content = new StringContent(csv);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "export.csv" };
                    return result;

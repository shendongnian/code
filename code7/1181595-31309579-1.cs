    context.Response.ContentType = "application/octet-stream";
                        // context.Response.AddHeader("content-disposition", "attachment;filename=abc.jpg" + Path.GetFileName(file));
                        context.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                        //context.Response.w(file);
                        context.Response.OutputStream.Write(data, 0, data.Length);
                      
                        //you can also implement other business request such as delete the file after download
                        context.Response.End();

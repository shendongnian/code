                    var fileInfo = new FileInfo(filePath);
                    context.Response.Clear();
                    context.Response.Buffer = true;
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                    context.Response.AddHeader("Content-Length", fileInfo.Length.ToString(CultureInfo.InvariantCulture));
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.BinaryWrite(File.ReadAllBytes(fileInfo.FullName));

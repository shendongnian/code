    [Route("api/dashboard/GetImage")]
    public byte[] GetImage(int componentId)
    {
                using (var dashboardService = new DashboardService())
                {
                    var component = dashboardService.GetImage(componentId);
                    var context = HttpContext.Current;
                    string filePath = context.Server.MapPath("~/Images/" + component.ImageName);
                    context.Response.ContentType = "image/jpeg";
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            fileStream.CopyTo(memoryStream);
                            Bitmap image = new Bitmap(1, 1);
                            image.Save(memoryStream, ImageFormat.Jpeg);
    
                            byte[] byteImage = memoryStream.ToArray();
                            return byteImage;
                        }
                    }
                }
    }

    [HttpPost]
            public ActionResult SaveImage(CampaignViewModel model, string imageData)
            {
                //path of folder taht you want to save the canvas
                var path = Server.MapPath("~/images/canvaseimg");
                //produce new file name
                var fileName =   GetPictureName(path);
                //get full file path
                var fileNameWitPath = Path.Combine(path, fileName);
    
                //save canvas
                using (var fs = new FileStream(fileNameWitPath, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        var data = Convert.FromBase64String(imageData);
                        bw.Write(data);
                        bw.Close();
                    }
                    fs.Close();
                }
    
                //do somthing with model
                return RedirectToAction("Index", "Home");
            }

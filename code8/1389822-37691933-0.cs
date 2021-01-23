    [HttpPost]
    public ActionResult UploadMultipleFiles()
    {
            FileUploadService service = new FileUploadService();
            var postedFile = Request.Files[0];
            StreamReader sr = new StreamReader(postedFile.InputStream);
            StringBuilder sb = new StringBuilder();
            DataTable dt = CreateTable();
            DataRow dr;
            string s;
            int j = 0;
            while (!sr.EndOfStream)
            {
                while ((s = sr.ReadLine()) != null)
                {
                    //Ignore first row as it consists of headers
                    if (j > 0)
                    {
                        string[] str = s.Split(',');
                        dr = dt.NewRow();
                        dr["Postcode"] = str[0].ToString();
                        dr["Latitude"] = str[2].ToString();
                        dr["Longitude"] = str[3].ToString();
                        dr["County"] = str[7].ToString();
                        dr["District"] = str[8].ToString();
                        dr["Ward"] = str[9].ToString();
                        dr["CountryRegion"] = str[12].ToString();
                        dt.Rows.Add(dr);
                    }
                    j++;
                }
            }
            service.SaveFilesDetails(dt);
            sr.Close();
            return View("Index");
        }

    public ActionResult PreDownload(int ID)
        {
            SoftwareLicense softwareLicense = db.SoftwareLicenses.Find(ID);
            TempData["SoftwareID"] = softwareLicense.SoftwareID;
            var fileNames = softwareLicense.LicenseFileName.Split(',');
            List<string> downloadList = new List<string>();
            foreach(string fileName in fileNames)
            {
                if(fileName.Length > 1)
                {
                    downloadList.Add(softwareLicense.SoftwareName + '_' + fileName);
                }
            }
            SetUserInfo();
            return View("DownloadList", downloadList);
        }

    [HttpPost]
    public ActionResult CreateMain(BulletinsViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            BulletinsContext.tblBulletins.Add(new tblBulletin
            {
                ID = viewModel.BulletinID,
                BulletinDisplayDate = viewModel.BulletinDisplayDate,
                BulletinFilename = viewModel.MainBulletinName
            });
            //Delete files older than X amount of days
            DirectoryInfo DI = new DirectoryInfo("D:/Inetpub/WWWroot/intranet/Dashboard/Dashboard/Files/Bulletins");
            FileSystemInfo[] FSI = DI.GetFiles();
            foreach (FileSystemInfo fInfo in FSI)
            {
                if (fInfo.Extension == ".pdf")
                {
                    DateTime dt = DateTime.Now.AddDays(-10);
                    if (fInfo.LastWriteTime < dt)
                        try
                        {
                            fInfo.Delete();
                        }
                        catch { }
                }
            }
            BulletinsContext.SaveChanges();
            return RedirectToAction("MainBulletins");
        }

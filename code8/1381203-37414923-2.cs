    [HttpPost]
    public JsonResult UploadFile(string stuff, HttpPostedFileBase file)
    {
        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
        string extension = Path.GetExtension(file.FileName);
    
        //save the file
        try
        {
            file.SaveAs('somePath' + fileName + extension);
        }
        catch (IOException exc)
        {
            return Json(new { status = 'error', message = exc.Message });
        }
    
        return Json('horray');
    }

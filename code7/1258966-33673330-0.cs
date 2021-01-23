        public ActionResult DownLoadFile(int Id)
        {
            var model = new PreviewFileAttachmentViewModel(Id, _attachFileProvider);
            if (model.FileExist)
                return File(model.AbsFileNamePath, model.ContentType, model.FileName);
            else
                return RedirectToAction("FileNotFound");
        }

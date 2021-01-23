    public ActionResult Create(QuestionCreateViewModel viewModel)
    {
        var question = new Question
        {
            Text = viewModel.Text,
            QuestionType = viewModel.QuestionType,
            Answer = viewModel.Answer,
            Notes = viewModel.Notes,
            CategoryId = viewModel.CategoryId,
            Files = ManageFiles(Request.Files)
        };
    
        _questionRepository.Insert(question);
        _questionRepository.Save();
    
        return Json(null);
    }
    
    private ICollection<File> ManageFiles(HttpFileCollectionBase fileCollection)
    {
        var files = new List<File>();
    
        for (var index = 0; index < fileCollection.Count; index++)
        {
            if (fileCollection[index] == null || fileCollection[index].ContentLength <= 0)
            {
                continue;
            }
    
            if (UploadFile(Request.Files[index]))
            {
                var file = new File
                {
                    Name = uploaded.FileName,
                    RelativePath = uploaded.FilePath + uploaded.FileName,
                    MimeType = uploaded.FileBase.ContentType,
                    Size = uploaded.FileBase.ContentLength
                };
    
                files.Add(file);
            }
        }
    
        return files;
    }

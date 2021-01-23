    [HttpPost]
        public ActionResult ACTION(ViewModels.Model taskModel)
        {
          string path = @"D:\Projects\TestApps\uploadedDocs\";
             if (taskModel.File != null) {
                    taskModel.File.SaveAs(path +taskModel.TaskTitle 
                                + taskModel.File.FileName);
                     newUserProject.DocumentTitle = taskModel.TaskTitle 
                                + taskModel.File.FileName;
                      newUserProject.DocumentPath = path + taskModel.File.FileName;
                        }
    }

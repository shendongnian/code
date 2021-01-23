        [HttpGet]
        public ActionResult CreateDirectory(string designId, CreateDirectoryModel model)
        {
            string customerSchema = SfsHelpers.StateHelper.GetSchema();
            TemplateLibraryEntry entry = GetTemplateLibraryEntry(model.DesignId, customerSchema);
            var path = Path.Combine(Server.MapPath("~/"), entry.FilePath);
            model.DesignId = designId;
            model.Directories = new List<string>();
            model.Directories.Add("/");
            model.Directories.AddRange(Directory.GetDirectories(path, "*", SearchOption.AllDirectories));
            for (int i = 1; i < model.Directories.Count; i++) {
                model.Directories[i] = model.Directories[i].Substring(path.Length).Replace('\\', '/');
            }
            model.Directories.Sort();
            //
			Mapper.CreateMap<CreateDirectoryModel,UploadViewModel>();
			var uploadmodel=Mapper.Map<UploadViewModel>(model);
			uploadmodel.Directories.Sort();
			//
            return View(model);
        }

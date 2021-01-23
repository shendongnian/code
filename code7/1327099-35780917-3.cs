        private ICommand _newScriptCommand;
        public ICommand NewScriptCommand
        {
            get
            {
                if (_newScriptCommand == null)
                {
                    _newScriptCommand = new SimpleCommand((arg) =>
                    {
                        var script = new Model.Script()
                        {
                            Title = "New Script",
                            Description = "A new script.",
                            Body = ""
                        };
                        script.Tags.Add(MiscTag);
                        var vm = new EditQueryWindowVm(script);
                        var result = WindowManager.DisplayDialogFor(vm);
                        // if (result.HasValue && result.Value)
                        //{
                        script.VersionCode = Guid.NewGuid();
                        script.CreatedBy = CurrentUser;
                        script.CreatedDate = DateTime.Now.ToUniversalTime();
                        SaveScript(script);
                        //}
                    });
                }
                return _newScriptCommand;
            }
        }

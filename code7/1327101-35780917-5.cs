    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using SqlMetaQuery.Model;
    using SqlMetaQuery.ViewModels.ScriptList;
    using SqlMetaQuery.Windows.EditQuery;
    using WpfLib;
    
    namespace SqlMetaQuery.Windows.Main
    {
        class MainWindowVm : WpfLib.ViewModel
        {
            public MainWindowVm()
            {
                if (!IsInDesignMode)
                {
                    using (Context db = new Context())
                    {
                        ScriptTree = new ScriptTreeVm(db.Tags
                            .Include(t => t.Scripts)
                            .OrderBy(t => t.Name));
    
                        CurrentUser = db.Users.Where(u => u.UserName == "Admin").AsNoTracking().FirstOrDefault();
                        MiscTag = db.Tags.Where(t => t.Name == "Misc").AsNoTracking().FirstOrDefault();
    
                    }
                }
            }
    
            public ScriptTreeVm ScriptTree { get; }
    
            public Model.User CurrentUser { get; }
    
            private Model.Tag MiscTag { get; }
    
            private void SaveScript(Model.Script script)
            {
                using (var context = new Model.Context())
                {
                    context.Scripts.Add(script);
                    context.SaveChanges();
                }
            }
    
            #region Commands
    
            private ICommand _exitCommand;
            public ICommand ExitCommand
            {
                get
                {
                    if (_exitCommand == null)
                    {
                        _exitCommand = new SimpleCommand((arg) => WindowManager.CloseAll());
                    }
                    return _exitCommand;
                }
            }
    
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
    
    
            #endregion
        }
    }

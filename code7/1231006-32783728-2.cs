      public override async Task<bool> CanClose()
        {
            return await SavePendingChanges();
        }
       public async Task<bool> SavePendingChanges()
            {
                if (!Entity.HasDirtyContents())
                    return true;
                bool? dialogResult = DialogProvider.ShowMessageBox("Save changes",
                    "There are pending changes, do you want to save them ?", MsgBoxButton.YesNoCancel);
                if (dialogResult == null)
                    return false;//user cancelled 
                if (dialogResult == false)
                    return true;//user doesn't want to save, but continue
                //try to save; if save failed => return false
                return await Save();
            }

    public bool UpdateTask(TimesheetListModel task)
    {
        var entity = DataContext.tblWorkLogs.FirstOrDefault(twl => twl.Id == task.Id);
        if (entity != null)
        {
          entity.AccountId = userId;     
          entity.WorkDate = task.Date;
          entity.Note = task.Note;       
          entity.TaskTitle = task.Task;
          DataContext.SubmitChanges();
          return true;
        }
        
        return false;
    }

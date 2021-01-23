    class TaskForm : Form
    {
       public LogForm MyLogForm;
       public void updateLogs()
       {
           MyLogForm.UpdateLog(new LogEntry());
       }
    }

    [WemMethod]
    public async Task<List<ErrorLog>> GetAllErrorLogs()
    {
    List<ErrorLog> errorLogs = new List<ErrorLog>();
    await System.Threading.Tasks.Task.Run(() => {
        errorLogs = ErrorLogRepository.GetAllErrorLogs();
    })
    if (errorLogs == null)
        return new List<ErrorLog>();
    return errorLogs;
    }

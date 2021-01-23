    public bool GetSubItem(string parentId)
    {
        System.Threading.AutoResetEvent autoEvent = new System.Threading.AutoResetEvent(false);
        bool isSuccess = false;
        _service.Communication<ViewModel, Request, Response>((ViewModel vm, ref Request) => 
       {
           request.ApiName = Const.FXXXName;
           request.Id = parentId;
       }, (viewModel, response, error) =>
       {
           DoSomething();
           ...
           isSuccess = response.IsOk;   // I put a breakpoint here
           autoEvent.Set();
       }
       autoEvent.WaitOne();
       return isSuccess;   // I also put a breakpoint here
    }

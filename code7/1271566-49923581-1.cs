    public void IncluirTicket(string messageShort, string observacao)
    {
      // Define parameters of request.
      listRequest = service.Tasklists.List();
      listRequest.MaxResults = 10000;
    
      // List task lists.
      IList<TaskList> taskList = listRequest.Execute().Items;
      var listaPendencias = taskList.Where(x => x.Title == "pendencias").ToList();
      var listaPendenciasID = listaPendencias[0].Id;
    
      Google.Apis.Tasks.v1.Data.Task task = new Google.Apis.Tasks.v1.Data.Task { Title = messageShort };
      task.Notes = observacao;
      task.Due = DateTime.Now;
    
      Google.Apis.Tasks.v1.Data.Task result = service.Tasks.Insert(task, listaPendenciasID).Execute();
      Console.WriteLine(result.Title);
    }

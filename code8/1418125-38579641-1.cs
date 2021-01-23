    public async void UpdateDocumentsListFromServer(object o, EventArgs args)
            {
                // This will execute async and return when complete
                await Task.Run(()=>{
                  var tempDocuments = model.GetDocumentsFromServer();
                  foreach (var item in tempDocuments)
                  {
                      this.shippingDocuments.Add(item);
                  }
                });
                //
            }

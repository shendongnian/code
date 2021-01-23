    public async void UpdateDocumentsListFromServer(object o, EventArgs args)
            {
                // Execute on background thread and put results into items
                var items = await Task.Run(()=>{
                  var tempDocuments = model.GetDocumentsFromServer();                  
                  return tempDocuments;
                });
                //add occurs on UI thread.
                this.shippingDocuments.AddRange(tempDocuments);
            }

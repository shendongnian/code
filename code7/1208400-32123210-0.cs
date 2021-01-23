    protected void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            WritePadFileContent datacontext = (WritePadFileContent) senderElement.DataContext;
            e.Request.Data.Properties.Title = datacontext.Name.ToString();
            e.Request.Data.Properties.Description = "Some description"; // Optional
            e.Request.Data.SetText(datacontext.Description.ToString());
        }

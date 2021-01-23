    //Upload process calling method
    private void Upload(_model)
    {
       //calling BG worker
       UploadBGWorker.RunWorkerAsync(new Arguments(_model))
    }
    UploadBGWorker_DoWorker(Arguments e)
    {
       Model _model = e.model;//first execution
       gvPriceListDetails.Visible = false;
       lblLoading.BringToFront();
       lblLoading.Visible = true;
    
    //wait for the updateprocess to complete
       if(_svc.UpdatePriceList(_model))
       {
          UiHelpers.ShowSuccessForm("Price Lists Successfully Updated!");
          e.Result = true;
       }
    }
    
    UploadBGWorker_RunWorkerCompleted(Arguments e)
    {
       if(e.Result != null && e.Result == true)
       {
          //execute on successful upload
          EditingMode(false);
          ShowDetails(_model.PricelistID);  
       }
       //execute when update process is complete
       lblLoading.Visible = false;
       gvPriceListDetails.Visible = true;
    }

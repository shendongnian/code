    lock(_lockingObject)
    {
                    request.DataMessage = base.SaveChanges();
                    if (request.DataMessage.IsSuccess)
                    {
                        request.CustomID = arRequest.CustomID;                        
                        Task.Run(() => TaskWriteARAddLog(request, arTimestamp, arRequest, _tModel));
    
                    }
                
    }
    
    //where _lockingObject is a field on your class:
    
    object _lockingObject =new object();

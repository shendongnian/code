     var userListsTemp=null;
    foreach (int workFlowServiceDetail in workFlowServiceDetails)
    {
       using (var db = new AdminDb())
       {
          string workFlowServiceDtl = (from perm in db.WorkFlowPermission.AsNoTracking()
                                      where perm.WorkFlowPermissionId == workFlowServiceDetail
                                      select perm.Service).FirstOrDefault();
         //to select eligibility rules against this service
         string eligibility = (from definition in db.WorkFlowDefinition.AsNoTracking()
                              join model in db.WorkFlowModel.AsNoTracking()
                              on definition.WorkFlowDefinitionId equals model.WorkFlowDefinitionId
                              join permission in db.WorkFlowPermission.AsNoTracking()
                              on model.WorkFlowDefinitionId equals permission.WorkFlowDefinitionId
                              where model.ControllerNameId.Equals(current_ControllerId) && permission.WorkFlowPermissionId == workFlowServiceDetail
                              select permission.EligibilityRule).FirstOrDefault();
    
         if (eligibility == null)
         {
             string validationMessage = "";
             validationMessage = "Please set eligibility for workflow permission";
             serviceName = null;
             permissionId = 0;
             return new CustomBusinessServices() { strMessage = validationMessage };
         }
    
         string[] strTxt = workFlowServiceDtl.Split(';'); //split the service name by ';' and strore it in an array
         string serviceUrl = string.Empty;
         string workFlowServiceName = string.Empty;
         string classpath = string.Empty;
         workFlowServiceName = strTxt[0].ToString();
         workFlowServiceName = workFlowServiceName.Replace(" ", "");//get the service name by removing empty blank space for the word
         classpath = strTxt[1].ToString();
    
         //Invoke REST based service (like Node.Js service)
         if (strTxt.Length == 4)
         {
             serviceUrl = strTxt[3].ToString();
         }
    
         //Invoke c# based service
         else
         {
             serviceUrl = string.Empty;
         }
    
         var userLists = PermissionCallMethod(classpath, workFlowServiceName, new[] { workFlowImplemented, eligibility }, serviceUrl);
    
         /*****************************************Problem in this loop**********/
         if (userLists.UserList.Contains(userId))
         {
              serviceName = strTxt[0].ToString() + ";Aspir.Pan.Common.WorkFlowNotificationServices;" + strTxt[2].ToString();
              permissionId = workFlowServiceDetail;
              //return userLists;
    	      if(userListsTemp==null)
    	      {
    		      userListsTemp=userLists;
    	      }
    	      else
    	      {
    		      userListsTemp.Concat(userLists).ToList();	
    	      }    
          }
       }
    }
    serviceName = string.Empty;
    permissionId = 0;
    return null;

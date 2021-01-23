    Here's a simple method that will create a folder in Livelink. 
    
    //LAPI Example
        
    private int CreateFolder(int parentId, string folderName)
            {
    llSession = new LLSession(host, Convert.ToInt32(port), string.Empty, userId, userPwd);
                int folderId = 0;
                LAPI_DOCUMENTS llDoc;
                LLValue objectInfo = (new LLValue()).setAssoc();
                
                try
                {
                    llDoc = new LAPI_DOCUMENTS(llSession);
                    if (llDoc.AccessEnterpriseWS(objectInfo) == 0)
                    {
                        this.llDocuments = llDoc;
                        llDoc.CreateFolder(llVolume, parentId, folderName, objectInfo);
                        folderId = objectInfo.toInteger("ID");
    
                        log.Info(folderName + " folder created successfully");
                        return folderId;
                    }
                    else
                    {
                        log.Info(folderName + " could not be created");
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    return 0;
                }
            } 
    
    
    //WCF Example getting Node info
    
     private void GetNodeInfo()
            {
                AuthenticationClient authClient = new AuthenticationClient();
                DocumentManagementClient docMan = new DocumentManagementClient();
                DocumentManagement.OTAuthentication otAuth = new DocumentManagement.OTAuthentication();
                string authToken = authClient.AuthenticateUser(userId, userPwd);
                otAuth.AuthenticationToken = authToken;
    
                try
                {
                  DocumentManagement.Node node = new Node();
    
                  node = docMan.GetNode(otAuth, Convert.ToInt32(dataRow[dataColumn].ToString()));
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
                finally
                {
                    authClient.Close();
                    docMan.Close();
                }
            }

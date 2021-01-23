            if (!IsPostBack)
            {
     try
                   {
                        log += "START\n";
                        string docId = Request.QueryString["docId"];
    
                        if (!String.IsNullOrEmpty(docName))
                        {
                            bool docExists = doesDocExist(docId);
    
                            if (docExists == true)
                            {
                                string docMetadata = getMetadata(docId);
                                Response.Write(docMetadata);
                            }
                        }
                        else 
                        {
                            // display error message
                        }
                    }
                    catch (sqlException sqlex) 
                    {
                        // process exception
                        sendErrorMessage(sqlex.Message);
                    }
                    catch (Exception ex)
                    {
                        // process exception
                        sendErrorMessage(ex.Message);
                    }
                }
            }

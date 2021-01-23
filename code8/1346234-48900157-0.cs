    TreeProvider tree = new TreeProvider(UserInfoProvider.GetUserInfo("SomeoneWithPermissionsToPublish"));
    
            int documentID = 1;
            //get document
            var doc = DocumentHelper.GetDocument(documentID, tree); // change DocumentID
            if (doc != null)
            {
                // Create a new Version manager instance
                VersionManager manager = VersionManager.GetInstance(tree);
    
                // Check out the document
                manager.CheckOut(doc);
    
                // do changes here
    
                // Save the changes
                DocumentHelper.UpdateDocument(doc, tree);
    
                // Check in the document
                manager.CheckIn(doc, null, null);
    
                WorkflowManager workflowManager = WorkflowManager.GetInstance(tree);
    
                WorkflowInfo workflow = workflowManager.GetNodeWorkflow(doc);
    
                // apply latest version
                manager.ApplyLatestVersion(doc);
    
                // Check if the document uses workflow
                if (workflow != null)
                {
                    // Publish the document
                    workflowManager.PublishDocument(doc, null);
                }
            }

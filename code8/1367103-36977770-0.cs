     ProjectNumbers = DatabaseHandler.Instance.QuerySingleColumn(SelectProjectNumberQuery, "ProjectNumber");
              foreach (string ProjectNumber in ProjectNumbers)
              {
                                     var node = new TreeNode(ProjectNumber);
    
                     SelectWorkOrderNumberQuery = "SELECT DISTINCT WorkOrderNumber FROM dbo.SUBPRODUCTS WHERE ProjectNumber =" + Int32.Parse(ProjectNumber) + ";";
                     WorkOrderNumbers = DatabaseHandler.Instance.QuerySingleColumn(SelectWorkOrderNumberQuery, "WorkOrderNumber");
                          foreach(string WorkOrderNumber in WorkOrderNumbers)
                          {                 
                                var workNode = new TreeNode(WorkOrderNumber);
                        node.Nodes.Add(workNode);
                          }
     ProjectTree.Nodes.Add(node);
              }

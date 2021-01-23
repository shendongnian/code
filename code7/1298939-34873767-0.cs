    if (tSelectedNodeType == 0)
      {
              gCommand = gConnection.CreateCommand();
              lock(LockObject)
              {
                  this.ExecuteNonQuery(String.Format("INSERT INTO tblNodes    (nodeName,nodeType,nodeSubID,isVisible) VALUES ('{0}',1,'{1}',1)", pCustomerName, tSelectedID));
            }
      }

        public BO.OperationResult UpdateConnectionType(int connectionTypeID, string connectionTypeDesc)
        {
            var operationResult = new BO.OperationResult();
            if (connectionTypeDesc.Trim().Length <= 0)
            {
                operationResult.Successful = false;
                operationResult.Message += "Connection Type Description has not successfully updated.";
            }
            if (operationResult.Successful)
            {
                operationResult.DBPrimaryKey = new DAL.AccountTrackerDAL().UpdateConnectionType(connectionTypeID, "Default", connectionTypeDesc, false);
                operationResult.Message = "Account Access Level Saved Successfully";
            }
            return operationResult;
        }

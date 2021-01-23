    public async Task<TableResult> ExecuteAsync(CloudTable table, TableOperation operation)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table));
        }
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }
    
        try
        {
            var result = await table.ExecuteAsync(operation);
            return result;
        }
        catch (Exception ex)
        {
            var errorMessage = GetStorageErrorMessage(ex);
            var statusCode = GetStorageStatusCode(ex);
            var message = string.Format(CultureInfo.CurrentCulture, AzureStorageResources.StorageManager_OperationFailed, statusCode, errorMessage);
            _logger.Error(message, ex);
    
            return new TableResult { HttpStatusCode = statusCode };
        }
    }
    
    public string GetStorageErrorMessage(Exception ex)
    {
        if (ex is StorageException storageException && storageException.RequestInformation != null)
        {
            var status = storageException.RequestInformation.HttpStatusMessage != null ?
                storageException.RequestInformation.HttpStatusMessage + " " :
                string.Empty;
            var errorCode = storageException.RequestInformation.ExtendedErrorInformation != null ?
                "(" + storageException.RequestInformation.ExtendedErrorInformation.ErrorMessage + ")" :
                string.Empty;
            return status + errorCode;
        }
        else if (ex != null)
        {
            return ex.Message;
        }
        return string.Empty;
    }
    
    public int GetStorageStatusCode(Exception ex)
    {
        return ex is StorageException se && se.RequestInformation != null ? se.RequestInformation.HttpStatusCode : 500;
    }

    try
    {
    	_client.DescribeTable(tableName);
    }
    catch (AmazonServiceException amazonServiceException)
    {
    	if (amazonServiceException.GetType() != typeof(ResourceNotFoundException))
        {
    	    throw;
        }
    
        return false;
    }
    
    return true;

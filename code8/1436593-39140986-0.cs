    public bool IsEmbedded(Workbook workbook)
    {
        try
        {
            // via the container you get a handle to the parent Word document object
            var container = workbook.Container;
            return true;
        }
        catch (COMException ex)
        {
            if (ex.ErrorCode == -2146822566)
            {
                // Exception message is: 
                // "This property is only available if the document is an OLE object."   
                return false;
            }
            throw;
        }
    }

    private string getFileLocation(string LinkGuid)
    {
        try
        {
            Guid search = Guid.Parse(LinkGuid);
            ISESEntities context = new ISESEntities();
            string query = (from f in context.tbFileAttachments
                    where f.CCCPGUID.ToString() == search
                    select f.FileLocation).First();
            return query;           
        }
        catch(Exception e)
        {
           blah blah
        }
    }

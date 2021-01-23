    public ActionConfirmation<string> CreateUpdateEntity<TExternalEntity>(TExternalEntity entity)
    {
        if (entity is OrderHeader)
        {
            var orderHdr = (OrderHeader)entity; //<------ ERROR HERE
        }
        return null;
    }

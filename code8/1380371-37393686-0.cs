    [AcceptVerbs("COPY")]
    [Route("{id}")]
    public void Copy(int id)
    {
        _productManager.Copy(sourceProductId: id);
    }

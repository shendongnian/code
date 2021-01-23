    // template pattern applied in this function
    public virtual Tobject CompileEntityFromDocument<Tobject>(document document)
    {
        Tobject dummyObject = CreateEntity();
        SetAttributesForEntity(dummyObject, null, null);
        SetRelationsForEntity(dummyObject, null);
        return (Tobject)dummyObject;
    }
    public abstract void SetAttributesForEntity(object entity, document mainDocumentToCompileFrom, List<vfield> documentFieldRecords);
    public abstract Tobject CreateEntity<Tobject>();
    public virtual void SetRelationsForEntity<Tobject>(Tobject entity, List<vfield> documentFieldRecords)
    {
        //Do nothing in base
    }

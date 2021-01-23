    void IFieldMergingCallback.FieldMerging(FieldMergingArgs args)
    {
        Row row = (Row)args.Field.Start.GetAncestor(NodeType.Row);
        if (row != null)
        {
            //Your code...
        }
    }

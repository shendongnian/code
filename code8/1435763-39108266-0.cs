    Func<DataContainerResponse, DataResponse, DataContainerResponse> aggregateFunc =
    (result, item) =>
    {
        result.Prop1 += item.Prop1;
        result.Prop2 += item.Prop2;
        ...
        result.PropN += item.PropN;
        return result;
    }

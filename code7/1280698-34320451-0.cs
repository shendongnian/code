    catch (MobileServicePreconditionFailedException ex) {
      var serverValue = ex.Value;
      // Resolve in favor of our client by just using the server's version
      var item = operation.Item;
      item[MobileServiceSystemColumns.Version] = serverValue[MobileServiceSystemColumns.Version];
      // this will save the item changes to the local store so next Push()
      // will resolve this
      operation.UpdateOperationAsync(item)
      throw ex;

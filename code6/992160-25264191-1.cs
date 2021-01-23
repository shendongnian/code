    var item = new StateRequestItem(entity, propName, tcs);
    _stateRequestItemList.TryAdd(cacheKey, item);
    item.CancellationRegistration = cancellationToken.Register(() =>
    {
      StateRequestItem cancelledItem;
      if (!_stateRequestItemList.TryRemove(cacheKey, out cancelledItem))
        return;
      cancelledItem.TaskCompletionSource.TrySetCanceled();
    });
    _evtClient.SubmitStateRequest(entity, propName);

    _stateRequestItemList.TryAdd(cacheKey, new StateRequestItem(entity, propName, tcs));
    cancellationToken.Register(() =>
    {
      StateRequestItem cancelledItem;
      if (!_stateRequestItemList.TryRemove(cacheKey, out cancelledItem))
        return;
      cancelledItem.TaskCompletionSource.TrySetCanceled();
    });
    _evtClient.SubmitStateRequest(entity, propName);

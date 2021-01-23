    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
      {
        cts.CancelAfter(TimeSpan.FromSeconds(2));
        try
        {
          return await base.SendAsync(request, cancellationToken);
        }
        catch (OperationCanceledException ex)
        {
          if (cancellationToken.IsCancellationRequested)
            return null;
          LogTimeout(...);
          throw;
        }
        catch (Exception ex)
        {
          LogFailure(...);
          throw;
        }
        finally
        {
          LogComplete(...);
        }
      }
    }

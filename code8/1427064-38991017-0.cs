    TaskCompletionSource<bool> l_tcsResult = new TaskCompletionSource<bool>();
    Device.BeginInvokeOnMainThread(async () =>
    {
      try
      {
        m_sdDevice = await SerialDevice.FromIdAsync(p_strDeviceID);
        l_tcsResult.SetResult(true);
      }
      catch(Exception l_exError)
      {
        l_tcsResult.SetException(l_exError);
      }
    });
    await l_tcsResult.Task;

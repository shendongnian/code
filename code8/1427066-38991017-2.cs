      TaskCompletionSource<bool> l_tcsResult = new TaskCompletionSource<bool>();
      await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
        Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
        {
          try
          {
            m_sdDevice = await SerialDevice.FromIdAsync(p_strDeviceID);
            l_tcsResult.SetResult(true);
          }
          catch (Exception l_exError)
          {
            l_tcsResult.SetException(l_exError);
            System.Diagnostics.Debug.WriteLine(l_exError);
          }
        });
      await l_tcsResult.Task;

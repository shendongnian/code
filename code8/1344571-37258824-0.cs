      Public Sub InvokeOnUiThread(ByRef uiAction As Action, Optional ByRef doAsync As Boolean = False)
         Dim dispatchObject As Dispatcher = orderTicketView.Dispatcher
         If (dispatchObject Is Nothing OrElse dispatchObject.CheckAccess()) Then
            uiAction()
         Else
            If doAsync Then
               dispatchObject.BeginInvoke(uiAction, DispatcherPriority.Normal)
            Else
               dispatchObject.Invoke(uiAction, DispatcherPriority.Normal)
            End If
         End If
      End Sub

      Private Function GetFirstQuote(ByVal eType As BridgeTraderBuyIndicator) As DepthLevelViewModel
         Dim cView As ICollectionView
         Dim cSource As CollectionViewSource
         Dim retView As DepthLevelViewModel = Nothing
         If eType = BridgeTraderBuyIndicator.Buy Then
            cSource = multilegViewModel.AskCollection
         Else
            cSource = multilegViewModel.BidCollection
         End If
         Try
            cView = cSource.View()
            Dim enumerator As IEnumerator = cView.Cast(Of DepthLevelViewModel).GetEnumerator()
            Dim moved As Boolean = enumerator.MoveNext()
            If moved Then
               retView = DirectCast(enumerator.Current(), DepthLevelViewModel)
            Else
               ApplicationModel.Logger.WriteToLog((New StackFrame(0).GetMethod().Name) & ": ERROR - Unable to retrieve the first quote.", LoggerConstants.LogLevel.Heavy)
            End If
         Catch ex As Exception
            ApplicationModel.AppMsgBox.DebugMsg(ex, (New StackFrame(0).GetMethod().Name))
         End Try
         Return retView
      End Function

      Private Function GetFirstQuote(ByVal eType As MyTypeEnum) As DepthLevelViewModel
         Dim cView As ICollectionView
         Dim cSource As CollectionViewSource
         If eType = MyTypeEnum.Buy Then
            cSource = tabViewModel.AskCollection
         Else
            cSource = tabViewModel.BidCollection
         End If
         cView = cSource.View()
         Dim enumerator As IEnumerator = cView.Cast(Of DepthLevelViewModel).GetEnumerator()
         Dim moved As Boolean = enumerator.MoveNext()
         Dim retView As DepthLevelViewModel = DirectCast(enumerator.Current(), DepthLevelViewModel)
         Return retView
      End Function

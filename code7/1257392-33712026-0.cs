    	Dim _outliningManager As Outlining.IOutliningManager
    Dim _oldCollapsedRegions As List(Of ICollapsed)
	
	'Getting access to ServiceProvider
	<Import>
    Dim ServiceProvider As SVsServiceProvider
	
	'Getting IOutliningManagerService object
	 Dim componentModel As IComponentModel = ServiceProvider.GetService(GetType(SComponentModel))
     Dim outliningManagerService As IOutliningManagerService = componentModel.GetService(Of IOutliningManagerService)()
		
		'Creating IOutliningManager for current textView
		If outliningManagerService IsNot Nothing Then
            _outliningManager = outliningManagerService.GetOutliningManager(textView)
            If _outliningManager IsNot Nothing Then AddHandler _outliningManager.RegionsCollapsed, AddressOf RegionCollapsed
        		
		End If
		
		'Getting all regions and expand them
		If _outliningManager IsNot Nothing Then
            Dim snapshot = _textView.TextSnapshot
            Dim snapshotSpan = New Microsoft.VisualStudio.Text.SnapshotSpan(snapshot, New Microsoft.VisualStudio.Text.Span(0, snapshot.Length))
            _oldCollapsedRegions = _outliningManager.GetCollapsedRegions(snapshotSpan).ToList()
            For Each reg In _oldCollapsedRegions
                _outliningManager.Expand(reg)
            Next
        End If
		
		
	'Blocking regions collapsed
	Sub RegionCollapsed(sender As Object, e As RegionsCollapsedEventArgs)
        If Me.Visibility = Windows.Visibility.Visible Then
            For Each reg In e.CollapsedRegions
                _outliningManager.Expand(reg)
            Next
        End If
    End Sub

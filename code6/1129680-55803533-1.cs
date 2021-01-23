    IEnumerable<IDropArea> IOverlayWindowHost.GetDropAreas( LayoutFloatingWindowControl draggingWindow )
    {
      if( _areas != null )
        return _areas;
      bool isDraggingDocuments = draggingWindow.Model is LayoutDocumentFloatingWindow;
      _areas = new List<IDropArea>();
      if( !isDraggingDocuments )
      {
        _areas.Add( new DropArea<DockingManager>(
            this,
            DropAreaType.DockingManager ) );
        foreach( var areaHost in this.FindVisualChildren<LayoutAnchorablePaneControl>() )
        {
          if( areaHost.Model.Descendents().Any() )
          {
            _areas.Add( new DropArea<LayoutAnchorablePaneControl>(
                areaHost,
                DropAreaType.AnchorablePane ) );
          }
        }
      }
      // Determine if floatingWindow is configured to dock as document or not
      bool dockAsDocument = true;
      if (isDraggingDocuments == false)
      {
        var toolWindow = draggingWindow.Model as LayoutAnchorableFloatingWindow;
        if (toolWindow != null)
        {
          foreach (var item in GetAnchorableInFloatingWindow(draggingWindow))
          {
            if (item.CanDockAsTabbedDocument == false)
            {
              dockAsDocument = false;
              break;
            }
          }
        }
      }
      // Dock only documents and tools in DocumentPane if configuration does allow that
      if (dockAsDocument == true)
      {
        foreach( var areaHost in this.FindVisualChildren<LayoutDocumentPaneControl>() )
        {
          _areas.Add( new DropArea<LayoutDocumentPaneControl>(
              areaHost,
              DropAreaType.DocumentPane ) );
        }
      }
      foreach( var areaHost in this.FindVisualChildren<LayoutDocumentPaneGroupControl>() )
      {
        var documentGroupModel = areaHost.Model as LayoutDocumentPaneGroup;
        if( documentGroupModel.Children.Where( c => c.IsVisible ).Count() == 0 )
        {
          _areas.Add( new DropArea<LayoutDocumentPaneGroupControl>(
              areaHost,
              DropAreaType.DocumentPaneGroup ) );
        }
      }
      return _areas;
    }
    /// <summary>
    /// Finds all <see cref="LayoutAnchorable"/> objects (toolwindows) within a
    /// <see cref="LayoutFloatingWindow"/> (if any) and return them.
    /// </summary>
    /// <param name="draggingWindow"></param>
    /// <returns></returns>
    private IEnumerable<LayoutAnchorable> GetAnchorableInFloatingWindow(LayoutFloatingWindowControl draggingWindow)
    {
      var layoutAnchorableFloatingWindow = draggingWindow.Model as LayoutAnchorableFloatingWindow;
      if (layoutAnchorableFloatingWindow != null)
      {
          //big part of code for getting type
          var layoutAnchorablePane = layoutAnchorableFloatingWindow.SinglePane as LayoutAnchorablePane;
          if (layoutAnchorablePane != null
              && (layoutAnchorableFloatingWindow.IsSinglePane
              && layoutAnchorablePane.SelectedContent != null))
          {
              var layoutAnchorable = ((LayoutAnchorablePane)layoutAnchorableFloatingWindow.SinglePane).SelectedContent as LayoutAnchorable;
              yield return layoutAnchorable;
          }
          else
          {
            foreach (var item in GetLayoutAnchorable(layoutAnchorableFloatingWindow.RootPanel))
            {
              yield return item;
            }
          }
      }
    }
    /// <summary>
    /// Finds all <see cref="LayoutAnchorable"/> objects (toolwindows) within a
    /// <see cref="LayoutAnchorablePaneGroup"/> (if any) and return them.
    /// </summary>
    /// <param name="layoutAnchPaneGroup"></param>
    /// <returns></returns>
    internal IEnumerable<LayoutAnchorable> GetLayoutAnchorable(LayoutAnchorablePaneGroup layoutAnchPaneGroup)
    {
      if (layoutAnchPaneGroup != null)
      {
        foreach (var anchorable in layoutAnchPaneGroup.Descendents().OfType<LayoutAnchorable>())
        {
          yield return anchorable;
        }
      }
    }

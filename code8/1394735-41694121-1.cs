        internal void Show(LayoutAnchorControl anchor)
        {
            if (_model != null)
                throw new InvalidOperationException();
            _anchor = anchor;
            _model = anchor.Model as LayoutAnchorable;
            _side = (anchor.Model.Parent.Parent as LayoutAnchorSide).Side;
            _manager = _model.Root.Manager;
            CreateInternalGrid();
            _model.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_model_PropertyChanged);
            Visibility = System.Windows.Visibility.Visible;
            InvalidateMeasure();
    #if !DEBUG
            UpdateWindowPos();
    #endif
            Trace.WriteLine("LayoutAutoHideWindowControl.Show()");
        }

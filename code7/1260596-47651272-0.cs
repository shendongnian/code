        #region IsSelected
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(GoodsReceived_FromSupplier_PositionModel),
                new PropertyMetadata((bool)false,
                    new PropertyChangedCallback(OnIsSelectedChanged)));
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GoodsReceived_FromSupplier_PositionModel target = (GoodsReceived_FromSupplier_PositionModel)d;
            bool oldIsSelected = (bool)e.OldValue;
            bool newIsSelected = target.IsSelected;
            target.OnIsSelectedChanged(oldIsSelected, newIsSelected);
        }
        protected virtual void OnIsSelectedChanged(bool oldIsSelected, bool newIsSelected)
        {
           // Do what your need in your property changed event
           // In my case, I just raise the PropertyChanged for PropertyChangedEventHandler
           // RaisePropertyChanged(nameof(IsSelected));
        }
        #endregion

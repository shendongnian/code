    <TabControl ... yournamespace:SelectorAttachedProperties.IsSynchronizedWithCurrentItemFixEnabled="True" .../>
    private void OnCurrentChanging(object sender, CurrentChangingEventArgs e)
    {                   
        if (MessageBox.Show("Change tab?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.No)
        {
            e.Cancel = true;                    
        }                     
    }
    public static class SelectorAttachedProperties
    {
        private static Type _ownerType = typeof(SelectorAttachedProperties);
     
        #region IsSynchronizedWithCurrentItemFixEnabled
     
        public static readonly DependencyProperty IsSynchronizedWithCurrentItemFixEnabledProperty =
            DependencyProperty.RegisterAttached("IsSynchronizedWithCurrentItemFixEnabled", typeof(bool), _ownerType,
            new PropertyMetadata(false, OnIsSynchronizedWithCurrentItemFixEnabledChanged));
     
        public static bool GetIsSynchronizedWithCurrentItemFixEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSynchronizedWithCurrentItemFixEnabledProperty);
        }
     
        public static void SetIsSynchronizedWithCurrentItemFixEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSynchronizedWithCurrentItemFixEnabledProperty, value);
        }
     
        private static void OnIsSynchronizedWithCurrentItemFixEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Selector selector = d as Selector;
            if (selector == null || !(e.OldValue is bool && e.NewValue is bool) || e.OldValue == e.NewValue)
                return;
     
            bool enforceCurrentItemSync = (bool)e.NewValue;
            ICollectionView collectionView = null;
     
            EventHandler itemsSourceChangedHandler = null;
            itemsSourceChangedHandler = delegate
            {
                collectionView = selector.ItemsSource as ICollectionView;
                if (collectionView == null)
                    collectionView = CollectionViewSource.GetDefaultView(selector);
            };
     
            SelectionChangedEventHandler selectionChangedHanlder = null;
            selectionChangedHanlder = delegate
            {
                if (collectionView == null)
                    return;
     
                if (selector.IsSynchronizedWithCurrentItem == true && selector.SelectedItem != collectionView.CurrentItem)
                {
                    selector.IsSynchronizedWithCurrentItem = false;
                    selector.SelectedItem = collectionView.CurrentItem;
                    selector.IsSynchronizedWithCurrentItem = true;
                }
            };
     
            if (enforceCurrentItemSync)
            {
                TypeDescriptor.GetProperties(selector)["ItemsSource"].AddValueChanged(selector, itemsSourceChangedHandler);
                selector.SelectionChanged += selectionChangedHanlder;
            }
            else
            {
                TypeDescriptor.GetProperties(selector)["ItemsSource"].RemoveValueChanged(selector, itemsSourceChangedHandler);
                selector.SelectionChanged -= selectionChangedHanlder;
            }
        }
     
        #endregion IsSynchronizedWithCurrentItemFixEnabled
    }

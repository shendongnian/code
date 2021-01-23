    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows;
    using Xceed.Wpf.DataGrid;
    
    namespace XceedUtil
    {
        public class DataGridControlCustom : DataGridControl
        {
            public DataGridControlCustom()
            {
                SelectionChanged += OnSelectionChanged;
            }
    
            private void OnSelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
            {
                foreach (SelectionInfo selectionInfo in e.SelectionInfos)
                {
                    foreach (var item in selectionInfo.AddedItems)
                    {
                        PropertyInfo pi = item.GetType().GetProperty("IsSelected", BindingFlags.Public | BindingFlags.Instance);
                        if (pi != null && pi.CanWrite)
                        {
                            pi.SetValue(item, true);
                        }
                    }
                    foreach (var item in selectionInfo.RemovedItems)
                    {
                        PropertyInfo pi = item.GetType().GetProperty("IsSelected", BindingFlags.Public | BindingFlags.Instance);
                        if (pi != null && pi.CanWrite)
                        {
                            pi.SetValue(item, false);
                        }
                    }
                }
            }
    
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new CustomDataRow();
            }
        }
    
        public class CustomDataRow : DataRow, IWeakEventListener
        {
            protected override void PrepareContainer(DataGridContext dataGridContext, object item)
            {
                base.PrepareContainer(dataGridContext, item);
    
                PropertyInfo pi = item.GetType().GetProperty("IsSelected", BindingFlags.Public | BindingFlags.Instance);
                if (pi != null && pi.CanWrite)
                {
                    if ((bool)pi.GetValue(item) == true)
                    {
                        dataGridContext.SelectedItems.Add(item);
                    }
                }
                
                PropertyChangedEventManager.AddListener(item as INotifyPropertyChanged, this, "IsSelected");
            }
    
            private void UpdateSelectedItems(object item)
            {
                var selectedItems = DataGridControl.GetDataGridContext(this).SelectedItems;
                try
                {
                    PropertyInfo pi = item.GetType().GetProperty("IsSelected", BindingFlags.Public | BindingFlags.Instance);
                    if (pi != null && pi.CanWrite)
                    {
                        if ((bool) pi.GetValue(item) == true)
                        {
                            selectedItems.Add(item);
                        }
                        else
                        {
                            selectedItems.Remove(item);
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
    
                }
            }
    
            protected override void ClearContainer()
            {
                var item = this.DataContext;
                PropertyChangedEventManager.RemoveListener(item as INotifyPropertyChanged, this, "IsSelected");
    
                var selectedItems = DataGridControl.GetDataGridContext(this).SelectedItems.Remove(item);
    
                base.ClearContainer();
            }
    
            bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
            {
                if (managerType == typeof(PropertyChangedEventManager))
                {
                    this.UpdateSelectedItems(sender);
                }
    
                return true;
            }
        }
    }

    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace HQ.Wpf.Util
    {
    	public static class DataGridCellHelper
    	{
    		#region IsSingleClickInCell
    		public static readonly DependencyProperty IsSingleClickInCellProperty =
    			DependencyProperty.RegisterAttached("IsSingleClickInCell", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(false, OnIsSingleClickInCellSet)); public static void SetIsSingleClickInCell(UIElement element, bool value) { element.SetValue(IsSingleClickInCellProperty, value); }
    
    		public static bool GetIsSingleClickInCell(UIElement element)
    		{
    			return (bool)element.GetValue(IsSingleClickInCellProperty);
    		}
    
    		private static void OnIsSingleClickInCellSet(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    		{
    			if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
    			{
    				if ((bool)e.NewValue)
    				{
    					var dataGrid = sender as DataGrid;
    					Debug.Assert(dataGrid != null);
    					EventManager.RegisterClassHandler(typeof(DataGridCell),
    						DataGridCell.PreviewMouseLeftButtonUpEvent,
    						new RoutedEventHandler(OnPreviewMouseLeftButtonDown));
    				}
    			}
    		}
    
    		private static void OnPreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
    		{
    			DataGridCell cell = sender as DataGridCell;
    			if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
    			{
    				var checkBoxes = ControlHelper.FindVisualChildren<CheckBox>(cell);
    				if (checkBoxes != null && checkBoxes.Count() > 0)
    				{
    					foreach (var checkBox in checkBoxes)
    					{
    						if (checkBox.IsEnabled)
    						{
    							checkBox.Focus();
    							checkBox.IsChecked = !checkBox.IsChecked;
    							var bindingExpression = checkBox.GetBindingExpression(CheckBox.IsCheckedProperty); if (bindingExpression != null) { bindingExpression.UpdateSource(); }
    						}
    						break;
    					}
    				}
    			}
    		}
    		#endregion
    	}
    }

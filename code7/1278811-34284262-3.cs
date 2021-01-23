    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace WpfApplication2
    {
        public class DataGridExtensions
        {
            public static readonly DependencyProperty ScrollChangedCommandProperty = DependencyProperty.RegisterAttached(
                "ScrollChangedCommand", typeof(ICommand), typeof(DataGridExtensions),
                new PropertyMetadata(default(ICommand), OnScrollChangedCommandChanged));
    
            private static void OnScrollChangedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                DataGrid dataGrid = d as DataGrid;
                if (dataGrid == null)
                    return;
                if (e.NewValue != null)
                {
                    dataGrid.Loaded += DataGridOnLoaded;
                }
                else if (e.OldValue != null)
                {
                    dataGrid.Loaded -= DataGridOnLoaded;
                }
            }
    
            private static void DataGridOnLoaded(object sender, RoutedEventArgs routedEventArgs)
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid == null)
                    return;
    
                ScrollViewer scrollViewer = UIHelper.FindChildren<ScrollViewer>(dataGrid).FirstOrDefault();
                if (scrollViewer != null)
                {
                    scrollViewer.ScrollChanged += ScrollViewerOnScrollChanged;
                }
            }
    
            private static void ScrollViewerOnScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                DataGrid dataGrid = UIHelper.FindParent<DataGrid>(sender as ScrollViewer);
                if (dataGrid != null)
                {
                    ICommand command = GetScrollChangedCommand(dataGrid);
                    command.Execute(e);
                }
            }
    
            public static void SetScrollChangedCommand(DependencyObject element, ICommand value)
            {
                element.SetValue(ScrollChangedCommandProperty, value);
            }
    
            public static ICommand GetScrollChangedCommand(DependencyObject element)
            {
                return (ICommand)element.GetValue(ScrollChangedCommandProperty);
            }
        }
    }

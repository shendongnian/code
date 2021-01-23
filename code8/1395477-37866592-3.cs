    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace WpfApplication4
    {
    
       public class ListViewWithContextMenu : ListView
       {
           public ICommand PreviewCommand
           {
               get { return (ICommand)GetValue(PreviewCommandProperty); }
               set { SetValue(PreviewCommandProperty, value); }
           }
           public static readonly DependencyProperty PreviewCommandProperty =
            DependencyProperty.Register("PreviewCommand", typeof(ICommand), typeof(ListViewWithContextMenu));
           static ListViewWithContextMenu()
           {
               DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewWithContextMenu), new FrameworkPropertyMetadata(typeof(ListViewWithContextMenu)));
           }
       }
    }

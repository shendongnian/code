    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using System.Linq;
    
    namespace WpfStackOverflow.Controls
    {
        /// <summary>
        /// Interaction logic for MenuOpenOnlyOnClick.xaml
        /// </summary>
        public partial class MenuOpenOnlyOnClick : Menu
        {
            public MenuOpenOnlyOnClick()
            {
                InitializeComponent();            
            }
        }
    
        public class MenuItemNew : MenuItem
        {
            #region Constructors
            static MenuItemNew()
            {
                MenuItem.IsSubmenuOpenProperty.OverrideMetadata(typeof(MenuItemNew),
                    new FrameworkPropertyMetadata(false, MenuItem.IsSubmenuOpenProperty.DefaultMetadata.PropertyChangedCallback, CoerceIsSubmenuOpen));
            }
    
            public MenuItemNew()
            {
                this.PreviewMouseLeftButtonDown += MenuItemNew_PreviewMouseLeftButtonDown;
                this.LostFocus += MenuItemNew_LostFocus;
            }
            #endregion
    
            #region Event Handlers
            void MenuItemNew_LostFocus(object sender, RoutedEventArgs e)
            {
                MenuItemNew item = sender as MenuItemNew;
                item.IsMenuItemExpanded = false;
            }
    
            void MenuItemNew_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                MenuItemNew item = sender as MenuItemNew;
    
                if (item.Role == MenuItemRole.SubmenuHeader)
                {
                    IsMenuItemExpanded = !IsMenuItemExpanded;
                    IsSubmenuOpen = IsMenuItemExpanded;
                }
            }
            #endregion
    
            #region IsMenuItemExpanded Dependency Property
    
            public bool IsMenuItemExpanded
            {
                get { return (bool)GetValue(IsExpanderClickedProperty); }
                set { SetValue(IsExpanderClickedProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for IsMenuItemExpanded.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsExpanderClickedProperty =
                DependencyProperty.Register("IsMenuItemExpanded", typeof(bool), typeof(MenuItemNew),
                new PropertyMetadata(false, null));
            
            #endregion
    
            #region Overrides
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new MenuItemNew();
            }
            #endregion
    
            #region Dependency Property Callbacks
            private static object CoerceIsSubmenuOpen(DependencyObject d, object value)
            {
                if ((bool)value)
                {
                    MenuItemNew item = (MenuItemNew)d;
    
                    if (item.Role == MenuItemRole.SubmenuHeader)
                    {
                        if (item.IsMenuItemExpanded)
                            return true;
                        else
                            return false;
                    }                
    
                    if (!item.IsLoaded)
                    {
                        item.Loaded += (s, e) =>
                        {
                            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new DispatcherOperationCallback(delegate(object param)
                            {
                                item.CoerceValue(MenuItemNew.IsSubmenuOpenProperty);
                                return null;
                            }), null);
                        };
                        return false;
                    }
                }
                return value;
            }
            #endregion  
        }
    }

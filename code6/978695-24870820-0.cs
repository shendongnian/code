    public partial class MyUserControl
    {
        public static readonly RoutedEvent TabItemSelectedEvent = 
            EventManager.RegisterRoutedEvent("TabItemSelected",
                         RoutingStrategy.Bubble, typeof(RoutedEventHandler), 
                         typeof(MyUserControl));
    
        public event RoutedEventHandler TabItemSelected
        {
            add { AddHandler(TabItemSelectedEvent, value); } 
            remove { RemoveHandler(TabItemSelectedEvent, value); }
        }
    
        void RaiseTabItemSelectedEvent()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(MyUserControl.TabItemSelectedEvent);
            RaiseEvent(newEventArgs);
        }
        private void TabControl_SelectionChanged(object sender,
                                                 SelectionChangedEventArgs e)
        {
            RaiseTabItemSelectedEvent();
        }    
    }

    //This class notifies listeners when child elements are added/removed & changed.
    public class ObservableCanvas : Canvas, INotifyPropertyChanged
    {
        //Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        //This function should be called when a child element has a property updated.
        protected virtual void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        //Create a routed event to indicate when the ObservableCanvas has changes to its child collection.
        public static readonly RoutedEvent VisualChildrenChangedEvent = EventManager.RegisterRoutedEvent(
            "VisualChildrenChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ObservableCanvas));
        //Create CLR event handler.
        public event RoutedEventHandler VisualChildrenChanged
        {
            add { AddHandler(VisualChildrenChangedEvent, value); }
            remove { RemoveHandler(VisualChildrenChangedEvent, value); }
        }
        //This function should be called to notify listeners
        //to changes to the child collection.
        protected virtual void RaiseVisualChildrenChanged()
        {
            RaiseEvent(new RoutedEventArgs(VisualChildrenChangedEvent));
        }
        //Override to make the changes public.
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            //Create bindings here to properties you need to monitor for changes.
            //This example shows how to listen for changes to the Fill property.
            //You may need to add more bindings depending on your needs.
            Binding binding = new Binding("Fill");
            binding.Source = visualAdded;
            binding.NotifyOnTargetUpdated = true;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            SetBinding(Shape.FillProperty, binding);
            //Instruct binding target updates to cause a global property
            //update for the ObservableCanvas.
            //This will make child property changes visible to the outside world.
            Binding.AddTargetUpdatedHandler(this,
                new EventHandler<DataTransferEventArgs>((object sender, DataTransferEventArgs e) =>
            {
                RaisePropertyChanged("Fill");
            }));
            //Notify listeners that the ObservableCanvas had an item added/removed.
            RaiseVisualChildrenChanged();
        }
    }

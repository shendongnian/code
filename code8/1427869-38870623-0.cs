    public Event RoutedEventHandler ButtonClicked 
    {
        add {
            ButtonName.Click += value; //use the name of your button here
        }
        remove {
            ButtonName.Click -= value;
        }
    }

    ObservableCollection<INamedItem> toppings = new ObservableCollection<INamedItem>();
    toppings.Add(new StringItem("Pepperoni"));
    toppings.Add(new StringItem("Ham"));
    toppings.Add(new StringItem("Sausage"));
    toppings.Add(new StringItem("Chicken"));
    toppings.Add(new StringItem("Mushroom"));
    toppings.Add(new StringItem("Onions"));
    toppings.Add(new StringItem("Olives"));
    toppings.Add(new StringItem("Bell Pepper"));
    toppings.Add(new StringItem("Pineapple"));
    //Now we can set the list property:
    dialog.Items = toppings;
    

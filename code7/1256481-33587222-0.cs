    void RemoveItem(string item, Action preRemoveLogic)
    {
       preRemoveLogic(); //we don't know what method this actually points to,
                         //but we can still call it.
       //remove the item
    }
    void MyCustomLogic()
    {
       //do something cool
    }
    /* snip */
    RemoveItem("the item", new Action(MyCustomLogic));

    [Flags]
    public enum MyChechboxes
    {
        FooCheckbox = 1,
        BarCheckbox = 2,
        BazCheckbox = 4,
    }
    int sum = 5;
    MyChechboxes checkeds = (MyChechboxes)sum;
    bool firstIsChecked = checkeds.HasFlag(MyChechboxes.FooCheckbox);
    bool secondIsChecked = checkeds.HasFlag(MyChechboxes.BarCheckbox);
    bool thirdIsChecked = checkeds.HasFlag(MyChechboxes.BazCheckbox); 

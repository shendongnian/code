    using System;
    using Xamarin.Forms;
    namespace SalesKicker
    {
    public class CustomSwitch : Switch
    {
    public static readonly BindableProperty TextOnProperty = BindableProperty.Create<CustomSwitch, string>(p => p.TextOn, AppResources.CustomSwitch_DefaultTextOn);
    public static readonly BindableProperty TextOffProperty = BindableProperty.Create<CustomSwitch, string>(p => p.TextOff, AppResources.CustomSwitch_DefaultTextOff);
    public string TxtOn
    {
        get { return (string)GetValue(TextOnProperty); }
        set { SetValue(TextOnProperty, value); }
    }
    public string TxtOff
    {
        get { return (string)GetValue(TextOffProperty); }
        set { SetValue(TextOffProperty, value); }
    }
    }
    }

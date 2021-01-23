    [assembly:ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
    namespace SalesKicker
    {
    public class CustomSwitchRenderer : SwitchRenderer
    {
    //the error is being thrown here: Error CS0115: 'CustomSwitchRenderer.OnElementChanged(ElementChangedEventArgs<CustomSwitch>)': no suitable method found to override (CS0115) (SalesKicker.Droid)
    protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
    {
        base.OnElementChanged(e);
        if (e.OldElement != null || this.Element == null)
				return;
        var customSwitch = this.Element;
        var control = new Switch(Forms.Context)
            {
                TextOn = customSwitch.TextOn,
                TextOff = customSwitch.TextOff
            };
        this.SetNativeControl(control);
    }
    }
    }

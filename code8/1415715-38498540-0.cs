    public static readonly BindableProperty StrokeColorProperty = 
        BindableProperty.Create("StrokeColor", 
                                typeof(Color), 
                                typeof(SignaturePadView), 
                                Color.Black, 
                                BindingMode.TwoWay,
    propertyChanged: (b, o, n) =>
                    {
                        var spv = (SignaturePadView)b;
                        //do something with spv
                        //o is the old value of the property
                        //n is the new value
                    });

    // @interface ICBarCodeReader : ICISMPDevice
    [DisableDefaultCtor]
    [BaseType(typeof(ICISMPDevice), Delegates = new[] { "WeakDelegate" }, Events = new[] { typeof(ICBarCodeReaderDelegate) }))]
    public interface ICBarCodeReader
    {
        [Wrap("WeakDelegate")]
        ICBarCodeReaderDelegate Delegate { get; set; }
        // @property (assign, nonatomic) id<ICISMPDeviceDelegate,ICBarCodeReaderDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        ICBarCodeReaderDelegate WeakDelegate { get; set; }
    }

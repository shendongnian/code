    // @interface ICBarCodeReader : ICISMPDevice
    [DisableDefaultCtor]
    [BaseType(typeof(ICISMPDevice))]
    public interface ICBarCodeReader
    {
        [Wrap("WeakDelegate")]
        ICBarCodeReaderDelegate Delegate { get; set; }
        // @property (assign, nonatomic) id<ICISMPDeviceDelegate,ICBarCodeReaderDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        ICBarCodeReaderDelegate WeakDelegate { get; set; }
    }

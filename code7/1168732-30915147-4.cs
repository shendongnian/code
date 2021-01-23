    [ComImport]
    [Guid("68ADA920-3B74-4978-AD6D-29F12A74E3DB")]
    [CoClass(typeof(ConcreteDynamicCode<>))]
    public interface IDynamicCode<out TCodeOut>
    {
        object DynamicClassInstance { get; set; }
        TCodeOut Execute(string value = "");
    }

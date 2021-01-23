    [Guid("599c264e-506e-3780-97b6-c1edff5f4a66")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface ISampleEventArgs {
        int Count { set; get; }
    }
    [Guid("37B8697D-BC5F-4CCB-8002-5F734B4765C8")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class SampleEventArgs : ISampleEventArgs {
        public int Count { set; get; }
    }

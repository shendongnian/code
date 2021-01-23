    // It defines no new methods or properties, just inherits it and acts as marker
    public interface IFsFileContainer : IFileContainer {}
    public interface IFtpFileContainer : IFileContainer {}
    public class FsFileContainer : IFsFileContainer
    {
        ...
    }

     public interface IFileStorage
     {
          ...
     }
     public interface IUploadStorage : IFileStorage { /* empty interface */ }
     public interface IContentStorage : IFileStorage { /* empty interface */ }
     public class FileStorage : IUploadStorage, IContentStorage
     {
          public FileStorage(string containerName)  { ... }
          ...
     }
     public UploadService(IUploadStorage storage) 
     {
         ...
     }
     public ContentService(IContentStorage storage)
     {
         ...
     }
     container.Register<IUploadStorage>(() = new FileStorage(Containers.Upload));
     container.Register<IContentStorage>(() = new FileStorage(Containers.Content));

      class Program
      {
          static void Main(string[] args)
          {
              ValidateChecksums(Path.GetFullPath("ConsoleApplication1.exe"));
          }
    
          // this needs a reference to Microsoft.DiaSymReader
          // or redefine its interfaces manually from here https://github.com/dotnet/roslyn/tree/master/src/Dependencies/Microsoft.DiaSymReader
          public static void ValidateChecksums(string filePath)
          {
              if (filePath == null)
                  throw new ArgumentNullException(nameof(filePath));
    
              var dispenser = (IMetaDataDispenser)new CorMetaDataDispenser();
              var import = dispenser.OpenScope(filePath, 0, typeof(IMetaDataImport).GUID);
    
              var binder = (ISymUnmanagedBinder)new CorSymBinder_SxS();
              ISymUnmanagedReader reader;
              binder.GetReaderForFile(import, filePath, null, out reader);
    
              int count;
              reader.GetDocuments(0, out count, null);
              if (count > 0)
              {
                  var docs = new ISymUnmanagedDocument[count];
                  reader.GetDocuments(count, out count, docs);
                  foreach (var d in docs)
                  {
                      var doc = new SymDocument(d);
                      Console.WriteLine(doc.Url);
    
                      if (doc.Checksum.SequenceEqual(doc.ComputeChecksum()))
                      {
                          Console.WriteLine(" checksum is valid.");
                      }
                      else
                      {
                          Console.WriteLine(" checksum is not valid.");
                      }
                  }
              }
          }
      }
    

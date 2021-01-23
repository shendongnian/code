      using System;
      using System.ComponentModel;
      using System.Diagnostics;
      using System.IO;
      using System.Web.UI;
      using System.Web.UI.HtmlControls;
      //------------------------------------------------------------------------------
      // ZetaLongPaths/Source/Runtime/ZlpSafeFileOperations.cs 
      // https://github.com/UweKeim/ZetaLongPaths/blob/master/Source/Runtime/ZlpSafeFileOperations.cs#L30
      //------------------------------------------------------------------------------
      namespace MyNameSpace {
          public class FileHandling {
              //------------------------------------------------------------------------------
              ///<summary>
              /// Simple File Operations Handling 
              ///</summary>
              ///<remarks>
              /// 
              ///</remarks>
              //------------------------------------------------------------------------------
              public static bool SafeFileExists(FileInfo filePath) {
                  return filePath != null && SafeFileExists(filePath.FullName);
              }
              public static bool SafeFileExists(string filePath) {
                  return !string.IsNullOrEmpty(filePath) && System.IO.File.Exists(filePath);
              }
              public static void SafeMoveFile(FileInfo sourcePath, FileInfo dstFilePath) {
                  SafeMoveFile(
                      sourcePath?.FullName.ToString(),
                      dstFilePath?.FullName);
              }
              public static void SafeDeleteFile(FileInfo filePath) {
                  if (filePath != null) {
                      SafeDeleteFile(filePath.FullName);
                  }
              }
              public static void SafeDeleteFile(
                  string filePath) {
                  Trace.TraceInformation(@"About to safe-delete file '{0}'.", filePath);
                  if (!string.IsNullOrEmpty(filePath) && SafeFileExists(filePath)) {
                      try {
                          var attributes = System.IO.File.GetAttributes(filePath);
                          // Remove read-only attributes.
                          if ((attributes & FileAttributes.ReadOnly) != 0) {
                              System.IO.File.SetAttributes(
                                  filePath,
                                  attributes & (~(FileAttributes.ReadOnly)));
                          }
                          System.IO.File.Delete(filePath);
                      } catch (UnauthorizedAccessException x) {
                          var newFilePath =
                              $@"{filePath}.{Guid.NewGuid():N}.deleted";
                          Trace.TraceWarning(@"Caught UnauthorizedAccessException while deleting file '{0}'. " +
                                             @"Renaming now to '{1}'. {2}", filePath, newFilePath, x.Message);
                          try {
                              System.IO.File.Move(
                                  filePath,
                                  newFilePath);
                          } catch (Win32Exception x2) {
                              Trace.TraceWarning(@"Caught IOException while renaming upon failed deleting file '{0}'. " +
                                                 @"Renaming now to '{1}'. {2}", filePath, newFilePath, x2.Message);
                          }
                      } catch (Win32Exception x) {
                          var newFilePath =
                              $@"{filePath}.{Guid.NewGuid():N}.deleted";
                          Trace.TraceWarning(@"Caught IOException while deleting file '{0}'. " +
                                             @"Renaming now to '{1}'. {2}", filePath, newFilePath, x.Message);
                          try {
                              System.IO.File.Move(
                                  filePath,
                                  newFilePath);
                          } catch (Win32Exception x2) {
                              Trace.TraceWarning(@"Caught IOException while renaming upon failed deleting file '{0}'. " +
                                                 @"Renaming now to '{1}'. {2}", filePath, newFilePath, x2.Message);
                          }
                      }
                  } else {
                      Trace.TraceInformation(@"Not safe-deleting file '{0}', " +
                                             @"because the file does not exist.", filePath);
                  }
              }
              public static void SafeMoveFile(string sourcePath, string dstFilePath) {
                  Trace.TraceInformation(@"About to safe-move file from '{0}' to '{1}'.", sourcePath, dstFilePath);
                  if (sourcePath == null || dstFilePath == null) {
                      Trace.TraceInformation(
                          string.Format(
                              @"Source file path or destination file path does not exist. " +
                              @"Not moving."
                              ));
                  } else {
                      if (SafeFileExists(sourcePath)) {
                          SafeDeleteFile(dstFilePath);
                          var d = Path.GetDirectoryName(dstFilePath);
                          if (!System.IO.Directory.Exists(d)) {
                              Trace.TraceInformation(@"Creating non-existing folder '{0}'.", d);
                              System.IO.Directory.CreateDirectory(d);
                          }
                          System.IO.File.Move(sourcePath, dstFilePath);
                      } else {
                          Trace.TraceInformation(@"Source file path to move does not exist: '{0}'.", sourcePath);
                      }
                  }
              }
          }
      }

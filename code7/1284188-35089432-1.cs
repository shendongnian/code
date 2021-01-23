    private void CmdTestButton(object sender, ExecutedRoutedEventArgs e) {
      Application.Current.Properties["FileOperationResult"] = new Dictionary<string, string>();
      using (FileOperation fo = new FileOperation(new PicFileOperationProgressSink())) {
        fo.CopyItem(@"d:\!test\003.jpg", @"d:\!test\aaa", "003.jpg");
        fo.PerformOperations();
      }
      var fileOperationResult = (Dictionary<string, string>) Application.Current.Properties["FileOperationResult"];
    }

      internal class Program
      {
        private static void Main(string[] args)
        {
          SomeClass someClass = new SomeClass();
          someClass.UploadProgress += SomeClass_UploadProgress;
          someClass.DoSomeUpload();
        }
    
        private static void SomeClass_UploadProgress(object sender, UploadEventArgs e)
        {
          string s = string.Format("sending file data {0:0.000}%", (e.BytesSoFar * 100.0f) / e.TotalToUpload);
          Console.WriteLine(s);
        }
      }
    
      public class UploadEventArgs : EventArgs
      {
        public float BytesSoFar { get; set; }
        public float TotalToUpload { get; set; }
      }
    
      public class SomeClass
      {
        public event EventHandler<UploadEventArgs> UploadProgress;
    
        public void DoSomeUpload()
        {
          if (UploadProgress != null)
          {
            UploadEventArgs e = new UploadEventArgs();
            e.BytesSoFar = 123f;
            e.TotalToUpload = 100000f;
            UploadProgress.Invoke(this, e);
          }
        }
      }

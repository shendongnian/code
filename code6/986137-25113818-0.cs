    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Bar;
    
    namespace Foo
    {
      public class CustomTask : Task
      {
        public override bool Execute()
        {
          Log.LogWarning( LogString.Get() );
          return true;
        }
      }
    }

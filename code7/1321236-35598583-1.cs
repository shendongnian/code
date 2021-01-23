     public class SomeClass
     {
       private WeakReference _weakactivity;
       private Activity _activity
       {
         get { return _weakactivity.Target as Activity; }
         set { _weakactivity = new WeakReference(value); }
       }
       public SomeClass(Activity activity)
       {
         _activity = activity;
       }
     }

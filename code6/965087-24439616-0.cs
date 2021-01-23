    public abstract class Car
    {
       private Point3D _loc;
       public event System.EventHandler LocationChanged;
       public Point3D Location 
       { 
          get{
              return _loc;
          }
         set; {
           _loc = value;
           if ( LocationChanged != null )
           {
              LocationChanged( this, new EventArgs() );
           }
         }
       }
     }

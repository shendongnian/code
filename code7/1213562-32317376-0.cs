       //ApiDefinition.cs
        [Static][Export ("polylineWithCoordinates:count:")][Internal]
     MGLPolyline PolylineWithCoordinates (IntPtr coords, nuint count);
    // Extra.cs
    public partial class MGLPolyline
    {
        public static unsafe MGLPolyline PolylineWithCoordinates(CLLocationCoordinate2D[] coords)
        {
            MGLPolyline line = null;
            fixed(void* arrPtr = coords)
            {
                IntPtr ptr = new IntPtr(arrPtr);
                line = MGLPolyline.PolylineWithCoordinates(ptr, 2);   
            }
            return line;
        }
    }

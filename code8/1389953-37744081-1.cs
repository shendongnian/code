    public class MainActivity : Activity, MyBroadcastReceiver.LocationDataInterface
    {
          ...
          public void OnLocationChanged(LatLng point)
          {
               // textview where you want to show location data
               locationText.Text += point.Latitude + "," + point.Longitude; 
               // things that you want to do with location point
          }      
    }

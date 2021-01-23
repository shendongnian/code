    public class scriptMove : MonoBehaviour{
    
      private float gpsLat;
      private float gpsLon;
      private float gpsAlt;
    
      void Start(){
        Input.location.Start(); //start service before querying location
        
        gpsLat = Input.location.lastData.latitude;
        gpsLon = Input.location.lastData.longitude;
        gpsAlt = Input.location.lastData.altitude;
    
        //Input.location.Stop(); //Stop service if there is no need to query Location updates continuously
      }
    
      void Update()
      {
        gpsLat = Input.location.lastData.latitude;
        gpsLon = Input.location.lastData.longitude;
        gpsAlt = Input.locaion.lastData.altitude;
      }
    }

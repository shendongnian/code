     //C#
        [WebMethod]
        public static List<Marker> RetrieveMarker()
        {
            List<Marker> markers = new List<Marker>();
            //Here you should have your table with data from database.
            for (int i = 0; i < tableMarker.Rows.Count; i++)
            {              
                Marker marker = new Marker();
                marker.ID = Convert.ToInt32(tableMarker.Rows[i]["IDmarker"]);
                marker.Latitud = Convert.ToDouble(tableMarker.Rows[j]["latitud"]);
                marker.Longitud = Convert.ToDouble(tableMarker.Rows[j]["longitud"]);
                markers.Add(marker);
            }
                //Return list of Marker object ,  javascript you receive Array of object
            return markers;
        }
        public class Marker
        {
            public int ID;
            public double Latitud;
            public double Longitud;
        }
        //C#
        //JavaScript
        var map;
        function InicializarMapa() {
    
            map = new google.maps.Map(document.getElementById('map_canvas'), {
                zoom: 10,
                center: new google.maps.LatLng(-32.960795281527304, -60.66179810739743), //change this
                zoomControl: true
            });
            google.maps.event.addDomListener(window, 'load', ReloadMarker);
      
        }
        function ReloadMarker(){
            PageMethods.RetrieveMarker(onSuccessRetrieveMarker);
        }
        function onSuccessRetrieveMarker(array of object from code behind (markers))
        {
             for (var i = 0; i < markers.length; i++) {
                  var myLatlng = new google.maps.LatLng(markers[i].Latitud,markers[i].Longitud);
                  var marker = new google.maps.Marker({
                  position: myLatlng,
                  map: map,
                  title: 'Hello World!'
                });
             }
             marker.setMap(map);
        }
        //JavaScript
        

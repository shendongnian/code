    using Microsoft.SqlServer.Server;
    using System.Collections;
    using System;
    namespace ProSQLSpatial
    {
        public partial class GoogleMaps
        {
            [SqlFunction(FillRowMethodName="FillRow")]
            public static IEnumerable GetGeoCodedResults(string address)
            {
                if (address == "test1")
                    yield return new GeoResponse { lat = 0.1d, lng = 0.2d };
                else
                    yield return new GeoResponse { lat = 0.2d, lng = 0.1d };
            }
            public static void FillRow(Object obj, out double lat, out double lng)
            {
                var entry = (GeoResponse)obj;
                lat = entry.lat;
                lng = entry.lng;
            }
        }
        public class GeoResponse
        {
            public double lat;
            public double lng;
        }
    }

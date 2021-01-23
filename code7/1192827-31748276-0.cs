    private void SetBoundingBoxLocationAndZoom(double latitudeCentre)
        {
            // 1024/1024 meters
            double desiredMapSize = 1024.0;
    
    
            int bestMatchMapSize = 0;
            int bestMatchMapResolution = 0;
            int bestMatchMapZoom = 0;
    
    
    
            //Starts with the largest zoom and ending with the smallest (remote) (min zoomLevel [1])
            // 1 - 21
            for (int zoom = 21; zoom >= 1; zoom--)
            {
                
                //Starts with the highest resolution and ending with the smallest (min pixel 80/80)
                // 80 - 834
                for (int resolution = 834; resolution >= 80; resolution--)
                {
                    double meterPerPixel = TileSystem.GroundResolution(latitudeCentre, zoom);
                    double mapSize = meterPerPixel * resolution;
    
                    if(Math.Abs(desiredMapSize - mapSize) < Math.Abs(desiredMapSize - bestMatchMapSize))
                    {
                        bestMatchMapSize = (int)mapSize;
                        bestMatchMapResolution = resolution;
                        bestMatchMapZoom = zoom;
                    }
                }
            }
    
    
            zoomLevel = bestMatchMapZoom;
            sizeMapInMeter = bestMatchMapSize;
            resolutionMap = bestMatchMapResolution;
    
            
    
        }
    
        /// <summary>
            /// Determines the ground resolution (in meters per pixel) at a specified
            /// latitude and level of detail.
            /// </summary>
            /// <param name="latitude">Latitude (in degrees) at which to measure the
            /// ground resolution.</param>
            /// <param name="levelOfDetail">Level of detail, from 1 (lowest detail)
            /// to 23 (highest detail).</param>
            /// <returns>The ground resolution, in meters per pixel.</returns>
            public static double GroundResolution(double latitude, int levelOfDetail)
            {
                latitude = Clip(latitude, MinLatitude, MaxLatitude);
                return Math.Cos(latitude * Math.PI / 180) * 2 * Math.PI * EarthRadius / MapSize(levelOfDetail);
            }

                geoposition = await geolocator.GetGeopositionAsync();
            }
            catch (UnauthorizedAccessException ue)
            {
                // Make sure you have defined ID_CAP_LOCATION in the application manifest 
                // and that on your phone, you have turned on location by checking 
                // Settings > Location.
                // Handle errors like unauthorized access to location services
            }
            catch (Exception ee)
            {
            }

            //Your Map Tapped
            Geopoint pointToReverseGeocode = new Geopoint(args.Location.Position);
            // Reverse geocode the specified geographic location.  
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);
            var resultText = new StringBuilder();
            try
            {
                if (result.Status == MapLocationFinderStatus.Success)
                {
                    resultText.AppendLine(result.Locations[0].Address.District + ", " + result.Locations[0].Address.Town + ", " + result.Locations[0].Address.Country);
                }
                MessageBox(resultText.ToString());
            }
            catch
            {
                //MessageBox(resultText.ToString());
                MessageBox("Please wait..");
            }
        }

                try
                {
                    // Look at target velocity and pick a conf file to use.
                    //
                    AlprNet alpr = new AlprNet("us", confPath, runtimeDirPath);
                    if (!alpr.isLoaded())
                    {
                        return;
                    }
                    // Optionally apply pattern matching for a particular region
                    alpr.DefaultRegion = "va"; // was md
                    alpr.DetectRegion = true;
                    AlprResultsNet results = alpr.recognize(chipPath);
                    ...
                    alpr.Dispose(); // Dispose of the object so it can clean up
                }

    IEnumerator InitLocationTracker()
        {
            // Start service before querying location
            Input.location.Start();
    
            // Wait until service initializes
    
            if (true == disableGPSMode)
            {
                //delegate to call again "InitLocationTracker"
    			if (null != OnRetryLocation)
    			{
    				OnRetryLocation ();
    			}
                //variable to check the location available
                isLocationAvailable = false;
    
                yield return null;
            }
            // I chose 20s to retry the call
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                // Service didn't initialize in 20 seconds
                if (maxWait < 1)
                {
                    Debug.Log("LocationTracker: Timed out");
                    
                    //GameObject to show error text
    				errorText.text = "LocationTracker: Timed out";
                    errorPanel.SetActive(true);
    
                    //delegate to call again "InitLocationTracker"
    				if (null != OnRetryLocation)
    				{
                        isLocationAvailable = false;
    					OnRetryLocation ();
    
                        yield break;
    				}
    
                    
                }
    
                yield return new WaitForSeconds(1f);
                maxWait--;
            }
    
            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("LocationTracker: Unable to determine device location");
    
    			errorText.text = "LocationTracker: Unable to determine device location";
                errorPanel.SetActive(true);
    
                
    			if (null != OnRetryLocation)
    			{
    				OnRetryLocation ();
    			}
    
                isLocationAvailable = false;
            }
            else
            {
                Debug.Log("LocationTracker Location: " + current_lat + " " + current_lon + " " + Input.location.lastData.timestamp);
                isLocationAvailable = true;
    
    
    			StartCoroutine(TrackLocation());
            }
        }

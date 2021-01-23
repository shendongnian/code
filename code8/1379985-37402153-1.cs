    // ANDREAS added this: In some cases we apparently don't get correct width and height until we have tried to read pixels
		// from the buffer.
		void TryDummySnapshot( ) {
			if(!gotAspect) {
				if( webCamTexture.width>16 ) {
					if( Application.platform == RuntimePlatform.IPhonePlayer ) {
						if(verbose)Debug.Log("Already got width height of WebCamTexture.");
					} else { 
					}
					gotAspect = true;
				} else {
					if(verbose)Debug.Log ("Taking dummy snapshot");
                    if( tmpImg == null ) {}
					Color32[] c = webCamTexture.GetPixels32();
				}
			}
		}

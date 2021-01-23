    // replaces the reflection cubemap for the selected environment (garage or gallery)
	public void setReflectionMaps(Cubemap cubeMap) 
	{
		// get all of the  mesh renderers
		var renderers = truckGO.GetComponentsInChildren<Renderer>();
		foreach (Renderer r in renderers) {
			// get the material for each renderer
			Material mat = r.sharedMaterial;
			// check if the material has a cubemap
			if (mat.HasProperty("_ReflectionMap")) {
				// replace existing cubemap
				mat.SetTexture("_ReflectionMap",cubeMap);
			}
		}
	}

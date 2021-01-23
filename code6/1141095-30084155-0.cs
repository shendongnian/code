	public void OnSceneGUI(){
		Camera camera = Camera.current;
		Handles.color = Color.red;
		Vector3 mp = Event.current.mousePosition;
		Ray ray = camera.ScreenPointToRay(mp);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)){
			Vector3 pos = hit.point;
			foreach(Vector3 handle in handles){
				if(Vector3.Distance(handle, pos) <= 0.05f){
					Handles.FreeMoveHandle(handle, Quaternion.identity, 0.001f, Vector3.zero, Handles.DotCap);
				}
			}
		}
	}

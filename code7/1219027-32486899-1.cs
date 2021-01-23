    public static Quaternion rot;
	void Start(){
		
		if (BackButtonScript.loadRot == true) {
			transform.Rotate(BackButtonScript.imgRot);
			
		}
	}
	public void OnMouseDrag(){
	
			Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 dir = Input.mousePosition - pos;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = rot;
			rot = Quaternion.AngleAxis (angle, Vector3.forward); 
	
	}

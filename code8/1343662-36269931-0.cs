    public static Vector3 GUIScale{
		get{
            float normalWidth = 1024; //Whatever design resolution you want
            float normalHeight = 768;
			return new Vector3(Screen.width / normalWidth, Screen.height / normalHeight, 1);
		}
	}
    public static Matrix4x4 AdjustedMatrix{
        get {
            return Matrix4x4.TRS(Vector3.zero, Quaternion.identity, GUIScale);
        }
    }
    void OnGUI(){
        GUI.matrix = AdjustedMatrix;
        (... GUI drawing code ...)
    }

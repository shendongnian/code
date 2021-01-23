	public class FieldReference
	{
		public GameObject gObject;
		public string component;
		public string fieldName;
		public string value {
			get {
				return gObject.GetComponent (component).GetType ().GetField (fieldName).GetValue (gObject.GetComponent (component)).ToString ();
			}
		}
	}

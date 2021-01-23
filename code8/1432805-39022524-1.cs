    public class Listener : MonoBehaviour
	{
		public EventContainer containor; // may assign from inspector
		void Awake()
		{
			containor.OnShow += Containor_OnShow;
			containor.OnHide += Containor_OnHide;
			containor.OnClose += Containor_OnClose;
		}
		void Containor_OnShow (string obj)
		{
			Debug.Log("Args from Show : " + obj);
		}
		void Containor_OnHide (string arg1, float arg2)
		{
			Debug.Log("Args from Hide : " + arg1);
			Debug.Log("Container's Hide called at " + arg2);
		}
		void Containor_OnClose (float obj)
		{
			Debug.Log("Container Closed called at : " + obj);
		}
	}

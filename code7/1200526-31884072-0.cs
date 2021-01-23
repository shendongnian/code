	public class MouseDownScript : MonoBehaviour
	{
		public List<Action> Actions = new List<Action>();
		
		void OnMouseDown(){
			foreach(Action action in Actions)
				action();
		}
	}

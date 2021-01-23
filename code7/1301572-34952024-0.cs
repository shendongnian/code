	public class RestartButton : MonoBehaviour 
	{
		GameObject persistentObject;
		void Start()
		{
			persistentObject = GameObject.Find("NameOfGameObject");
            int shouldReset = (persistentObject.GetComponent<SetRestart>() as SetRestart).Setrestart;
            if (shouldReset == 1) {
                Application.LoadLevel("Main");
            }
		}
	 }

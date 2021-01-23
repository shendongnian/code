    // this should run absolutely first; use script execution order
    // (of course normally never, ever, ever use script execution order,
    // this is an unusual case - just for development.)
    ...
    public class DevPreload:MonoBehaviour
     {
     void Awake()
      {
      GameObject check = GameObject.Find("__app");
      if (check==null)
       { UnityEngine.SceneManagement.SceneManager.LoadScene("_preload"); }
      }
     }

    public class Manager:MonoBehaviour {
        void Awake(){
            PanelCtrl.OnCompletion += HandleCompletion;
        }
    }
 
    private int flag = 3 
    void HandleCompletion (){
         if(--flag == 0){ Debug.Log("All done"); }
    }

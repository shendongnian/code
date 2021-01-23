    public class ScriptB : MonoBehaviour{
    
        ScriptA scriptInstance = null;  
    
        void Start()
        {
          GameObject tempObj = GameObject.Find("NameOfGameObjectScriptAIsAttachedTo");
          scriptInstance = tempObj.GetComponent<ScriptA>();
    
          //Access dictio  variable from ScriptA
          scriptInstance.dictio.Add("aaa", gameObject);
        }
    }

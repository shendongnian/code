    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    public class OpenFileButtonScript : MonoBehaviour {
    
        public string path;
    
        public void OpenDialog()
        {
            path = EditorUtility.OpenFilePanel(
                        "Open file",
                        "",
                        "*");
        }
    }

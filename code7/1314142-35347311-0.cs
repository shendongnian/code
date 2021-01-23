    using UnityEngine;
    using System.Collections;
    using System.IO;
    using UnityEngine.UI;
    public class ListScript : MonoBehaviour {
        public InputField word;
        void Start() {
        }
        public void NewList() {
           if (word != null) { 
               print(Application.persistentDataPath);
               File.AppendAllText(Application.persistentDataPath + "/test.txt", s.NewLine + word.text);
           }
        }
        void OnLevelWasLoaded(int level) {
            Debug.Log("I was here");
        }
    }

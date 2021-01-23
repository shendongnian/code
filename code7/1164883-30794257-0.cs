    using UnityEngine;
    using System.Collections;
    
    public class InfoInput : MonoBehaviour {
    
        public string charname  = "Name";
        public string usrname   = "User Name";
        public string charrace  = "Race";
        public string charclass = "Class";
        public string charalli  = "LG";
        public string next      = "Next";
        public GUISkin CustomGUI // Add the from the Inspector panel by drag and drop
    
        void OnGUI() {
            int x      = 500;
            int y      = 150;
            int w      = 260;
            int h      = 20;
            int buffer = 6;
    
            charname  = GUI.TextField (new Rect (x, y, w, h), charname, 24, CustomGUI);
            y = y + h + buffer;
            usrname   = GUI.TextField (new Rect (x, y, w, h), usrname, 24, CustomGUI);
            y = y + h + buffer;
            charrace  = GUI.TextField (new Rect (x, y, w, h), charrace, 12, CustomGUI);
            y = y + h + buffer;
            charclass = GUI.TextField (new Rect (x, y, w, h), charclass, 20, CustomGUI);
            y = y + h + buffer;
            charalli  = GUI.TextField (new Rect (x, y, w, h), charalli, 2, CustomGUI);
            y = y + h + buffer;
           GUI.Button (new Rect (x, y, w, y / 4), next, CustomGUI);  
        }
    }

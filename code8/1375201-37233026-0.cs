    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    
    [CustomEditor(typeof(OpenFileButtonScript))]
    public class customButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
    
            OpenFileButtonScript myScript = (OpenFileButtonScript)target;
            if (GUILayout.Button("Open File"))
            {
                myScript.OpenDialog();
            }
        }
    }

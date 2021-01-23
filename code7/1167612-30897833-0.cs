    using UnityEngine;
    using UnityEditor;
    
    [CanEditMultipleObjects, CustomEditor(typeof(Light))]
    public class LightEditor : Editor {
    	
    	bool editAllowed = false;
    	
    	public override void OnInspectorGUI () {
    		
    		EditorGUILayout.Space();
    		editAllowed = EditorGUILayout.ToggleLeft(" I know what I'm doing", editAllowed);
    		EditorGUILayout.Space();
    		
    		GUI.enabled = editAllowed;
    		DrawDefaultInspector();
    	}
    }

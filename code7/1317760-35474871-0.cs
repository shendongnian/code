    [CustomEditor(typeof(Change))]
    public class Change_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            // Grab the script.
            Change myTarget = target as Change;
            // Set the indentLevel to 0 as default (no indent).
            EditorGUI.indentLevel = 0;
            // Update
            serializedObject.Update();
    
            EditorGUILayout.BeginHorizontal();
    
            EditorGUILayout.BeginVertical();
    
            //  >>> NEW
            SerializedProperty sceneNames = this.serializedObject.FindProperty("SceneNames");
            EditorGUILayout.PropertyField(sceneNames.FindPropertyRelative("Array.size"));
    
            for(int i = 0; i < sceneNames.arraySize; i++)
            {
                EditorGUILayout.PropertyField(sceneNames.GetArrayElementAtIndex(i), GUIContent.none);
            }
            //  >>> NEW
    
            EditorGUILayout.EndVertical();
    
            EditorGUILayout.EndHorizontal();
    
            // Apply.
            serializedObject.ApplyModifiedProperties();
        }
    }

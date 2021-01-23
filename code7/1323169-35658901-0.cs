    public override void OnInspectorGUI()
    {
        EditorGUI.indentLevel = 0;
        serializedObject.Update();
        EditorGUILayout.PropertyField(posLook
                       .FindPropertyRelative("Array.size"));
        for(int i = 0; i < posLook.arraySize; i++)
        {
            SerializedProperty item = posLook.GetArrayElementAtIndex(i);
            SerializedProperty posLookArrayProperty = 
                item.FindPropertyRelative("PosLookArray");
            EditorGUILayout.PropertyField(
                posLookArrayProperty.FindPropertyRelative("Array.size"));
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Camera Position", 
                EditorStyles.boldLabel, GUILayout.Width(Screen.width / 2.8f));
            EditorGUILayout.LabelField("Camera Look", 
                EditorStyles.boldLabel, GUILayout.Width(Screen.width / 2.8f));
            EditorGUILayout.LabelField("Story", 
                EditorStyles.boldLabel, GUILayout.Width(75f));
            EditorGUILayout.EndHorizontal();
            for(int j = 0; j < posLookArrayProperty.arraySize; j++)
            {
                EditorGUILayout.PropertyField(
                    posLookArrayProperty.GetArrayElementAtIndex(j), GUIContent.none);
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

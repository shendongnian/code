        pubilc class Original_Editor : Editor{
             public override void OnInspectorGUI(){
                  serializedObject.Update();
		          // Get the camera width.
		          SerializedProperty width = serializedObject.FindProperty("cameraWidth");
		          // Set the layout.
		          EditorGUILayout.PropertyField(width);
		          // Clamp the desired values
		          width.floatValue = Mathf.Clamp((int)width.floatValue, 0, 9999);
		          // apply
		          serializedObject.ApplyModifiedProperties();
             }
        }

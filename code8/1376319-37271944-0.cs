    using System;
    using System.Collections;
    using System.Reflection;
    using UnityEditor;
     
    public class SceneViewGizmos {
    	private static bool _globalGizmosOn;
     
     
    	[MenuItem("Quick Fingers/Scene View/Toggle Gizmos &%g")] private static void ToggleAllSceneGizmos() {
    		_globalGizmosOn = !_globalGizmosOn;
    		ToggleGizmos(_globalGizmosOn);
    	}
     
    	[MenuItem("Quick Fingers/Scene View/Disable All Gizmos")] private static void DisableAllSceneGizmos() {
    		_globalGizmosOn = false;
    		ToggleGizmos(_globalGizmosOn);
    	}
     
    	[MenuItem("Quick Fingers/Scene View/Enable All Gizmos")] private static void EnableAllSceneGizmos() {
    		_globalGizmosOn = true;
    		ToggleGizmos(_globalGizmosOn);
    	}
     
    	private static void ToggleGizmos(bool gizmosOn) {
    		int val = gizmosOn ? 1 : 0;
    		Assembly asm = Assembly.GetAssembly(typeof(Editor));
    		Type type = asm.GetType("UnityEditor.AnnotationUtility");
    		if (type != null) {
    			MethodInfo getAnnotations = type.GetMethod("GetAnnotations", BindingFlags.Static | BindingFlags.NonPublic);
    			MethodInfo setGizmoEnabled = type.GetMethod("SetGizmoEnabled", BindingFlags.Static | BindingFlags.NonPublic);
    			MethodInfo setIconEnabled = type.GetMethod("SetIconEnabled", BindingFlags.Static | BindingFlags.NonPublic);
    			var annotations = getAnnotations.Invoke(null, null);
    			foreach (object annotation in (IEnumerable)annotations) {
    				Type annotationType = annotation.GetType();
    				FieldInfo classIdField = annotationType.GetField("classID", BindingFlags.Public | BindingFlags.Instance);
    				FieldInfo scriptClassField = annotationType.GetField("scriptClass", BindingFlags.Public | BindingFlags.Instance);
    				if (classIdField != null && scriptClassField != null) {
    					int classId = (int)classIdField.GetValue(annotation);
    					string scriptClass = (string)scriptClassField.GetValue(annotation);
    					setGizmoEnabled.Invoke(null, new object[] { classId, scriptClass, val });
    					setIconEnabled.Invoke(null, new object[] { classId, scriptClass, val });
    				}
    			}
    		}
    	}
    }

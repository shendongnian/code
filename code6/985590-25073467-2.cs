     SerializedProperty myCustomList = serializedObject.FindProperty ("myCustomList");
          
        for (int i = 0; i < myCustomList .arraySize; i++)
        {
        	SerializedProperty elementProperty = myCustomList.GetArrayElementAtIndex(i);
    
            //Since this the object is not UnityEngine.Object you can not convert them the unity way.  The compiler can determine the type that way so.....
    
           MyCustomList convertedMCL = elementProperty.objectReferenceValue as System.Object as MyCustomList;
        }
           
       

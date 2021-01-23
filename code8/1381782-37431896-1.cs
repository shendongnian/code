       void Start()
       {
            GameObject prefab = GameObject.Find("cat");
            Object GameObject2 = UnityEditor.PrefabUtility.GetPrefabParent(prefab);
            string prefabPath = UnityEditor.AssetDatabase.GetAssetPath(GameObject2);
            Debug.Log("Path: " + prefabPath);
        }

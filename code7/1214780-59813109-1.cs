        [UnityEditor.MenuItem("Assets/Create/Get Current Path")]
        static void GetCurrentPath(UnityEditor.MenuCommand menuCommand)
        {
            foreach(var g in UnityEditor.Selection.assetGUIDs)
                UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GUIDToAssetPath(g));
        }

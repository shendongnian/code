    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    public class ExportAssetBundles : Editor {
        [MenuItem("Assets/Build AssetBundle")]
        static void ExportResource()
        {
            string path = "Assets/AssetBundle/myAssetBundle.unity3d";
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path,
                                           BuildAssetBundleOptions.CollectDependencies
                                         | BuildAssetBundleOptions.CompleteAssets,BuildTarget.Android);
        }
    }

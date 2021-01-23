    class MyBuilder : Editor {
        private static string[] FillLevels ()
		{
			return (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray ();
		}
    
        [MenuItem ("MyTool/BuildGame")]
   		public static void  buildGame()
		{
			string[] levels = FillLevels ();
			foreach (string level in levels) {
				EditorApplication.OpenScene (level);
                object[] allObjects = Resources.FindObjectsOfTypeAll (typeof(UnityEngine.GameObject));
				foreach (object thisObject in allObjects) {
                   /* my gameObjects changing before compilation */
				}
				EditorApplication.SaveScene ();
			}
			BuildPipeline.BuildPlayer (levels, Path.GetFullPath (Application.dataPath + "/../game.exe"), BuildTarget.StandaloneWindows, BuildOptions.None);
		}
    }

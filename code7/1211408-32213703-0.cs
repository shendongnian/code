    public class LevelLoader : MonoBehaviour
        {
          void Start()
          {
            StartCoroutine(ReloadLevel());
          }
        
          IEnumerator ReloadLevel()
          {
            yield return Resources.UnloadUnusedAssets();
            Application.LoadLevel(Application.loadedLevelName);
          }

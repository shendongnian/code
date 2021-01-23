    public class LoadScene : MonoBehaviour {
    //public Variables
    public string url; // url where your asset bundle is present, can be your hard disk or ftp server
    public string AssetBundleName;
    public string levelName;
    public int version;
    //private variables
    private AssetBundle assetBundle; 
    /*Corountines
    By using this, the function will simply stop in that point until the WWW object is done downloading, 
    but it will not block the execution of the rest of the code, it yields until it is done.*/
    protected IEnumerator LoadTheScene()
    {
        if (!Caching.IsVersionCached(url + "/" + AssetBundleName, version)){
            WWW www = WWW.LoadFromCacheOrDownload(url + "/" + AssetBundleName, version);
            yeild return www;
            assetBundle = www.assetBundle;
            www.Dispose();
            if (assetBundle != null)
            {
                string[] path = assetBundle.GetAllScenePaths();
                //below code is for finding the "scene name" from the bundle
                foreach (string temp in path)
                {
                    Debug.Log(temp);
                    string[] name = temp.Split('/');
                    string[] sceneName = name[name.Length - 1].Split('.');
                    string result = sceneName[0];
                    if (result == levelName)
                    {
                        yield return (SceneManager.LoadSceneAsync(result));
                    }
                }
            }
        }
       
        else{
            Debug.Log("Asset Already Cached...");
            yield return Caching.CleanCache();
            //After using an asset bundle you should unload it otherwise an exception will be thrown saying asset bundle is already loaded.. if you use WWW.LoadFromCacheOrDownload again.
        }
    }
}

    IEnumerator Start() {
        if (PlayerPrefs.GetInt("AssetLoaded", 0) == 0){
            Debug.Log("Asset has NOT been downloaded. Downloading....");
            using (WWW www = WWW.LoadFromCacheOrDownload (BundleURL, version)) {
                yield return www;
                if (www.error != null)
                    throw new Exception ("WWW download had an error:" + www.error);
                if (www.error == null) {
                    AssetBundle bundle = www.assetBundle;
                }
            }
                if (Caching.ready == true) {
                    downloaded = 1;
                    PlayerPrefs.SetInt("AssetLoaded", 1);
                    yield return InitializeLevelAsync (sceneName, true);
                    
                }
            }else
              {
                 Debug.Log("Asset already loaded. Can't download it again! Loading it instead");
                 yield return InitializeLevelAsync (sceneName, true);
              }
        }

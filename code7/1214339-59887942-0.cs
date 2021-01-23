using UnityEngine;
public class MySceneBehaviour: MonoBehaviour {
    private static MySceneParams loadSceneRegister = null;
    
    public MySceneParams sceneParams;
    public static void loadMyScene(MySceneParams sceneParams, System.Action<MySceneOutcome> callback) {
        MySceneBehaviour.loadSceneRegister = sceneParams;
        sceneParams.callback = callback;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MyScene");
    }
    public void Awake() {
        if (loadSceneRegister != null) sceneParams = loadSceneRegister;
        loadSceneRegister = null; // the register has served its purpose, clear the state
    }
    public void endScene (MySceneOutcome outcome) {
        if (sceneParams.callback != null) sceneParams.callback(outcome);
        sceneParams.callback = null; // Protect against double calling;
    }
}
[System.Serializable]
public class MySceneParams {
    public System.Action<MySceneOutcome> callback;
    // + inputs of the scene 
}
public class MySceneOutcome {
    // + outputs of the scene 
}
You can keep global state in the *caller*'s scope, so scene inputs and outputs states can be minimized (makes testing easy). To use it you can use anonymous functions:-
MyBigGameServices services ...
MyBigGameState bigState ...
Splash.loadScene(bigState.player.name, () => {
   FirstLevel.loadScene(bigState.player, (firstLevelResult) => {
       // do something else
       services.savePlayer(firstLevelResult);
   })
)}
More info at https://corepox.net/devlog/unity-pattern:-stateless-scenes

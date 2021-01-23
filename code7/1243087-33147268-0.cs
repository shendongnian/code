    [MenuItem("Assets/Create/FlowEngine/Character")]
    private static void CreateCharacter()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        string assetPath = path + "/New Character.asset";
        FlowEngineCharacterData character = ScriptableObject.CreateInstance<FlowEngineCharacterData>();
        ProjectWindowUtil.CreateAsset(character, assetPath);
    }

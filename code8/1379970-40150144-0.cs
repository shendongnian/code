    // GunController.cs
    [SyncVar]
    public NetworkInstanceId parentNetId;
    public override void OnStartClient()
    {
        GameObject parentObject = ClientScene.FindLocalObject(parentNetId);
        transform.SetParent(parentObject.transform);
    }

    PumpItem pumpItem;
    if (pumpDict.TryGetValue(ID, out pumpItem))
    {
        pumpItem.state = PoSClientWPF.pumpState.Available;
    }
    else
    {
        pumpItem = new PumpItem();
        pumpDict.Add(ID, pumpItem);
    }

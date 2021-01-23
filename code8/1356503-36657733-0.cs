    PumpItem pump;
    if (pumpDict.TryGetValue(ID, out pump))
    {
        pumpItem.state = PoSClientWPF.pumpState.Available;
    }
    else
    {
        pump = new PumpItem();
        pumpDict.Add(ID, pump);
    }

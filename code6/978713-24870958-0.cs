    UpdatePanel1.Triggers.Add(new AsyncPostBackTrigger()
    {
        ControlID = useEtl,
        EventName = "SelectedIndexChanged", // this may be optional
    }

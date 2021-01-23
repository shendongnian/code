    if (fileProps.ContainsKey("System.Music.BeatsPerMinute"))
    {
        var bpmObj = fileProps["System.Music.BeatsPerMinute"];
        if (bpmObj != null)
        {
            var bpm = bpmObj.ToString();
        }
    }

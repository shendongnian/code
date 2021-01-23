    public static List<T> resultCollection GetControlsRec<T>(Control.ControlCollection controlCollection) where T : Control
    {
        ///Create new collection
        List<T> resultCollection = new List<T>();
        foreach (Control control in controlCollection)
        {
            if (control is T)
                resultCollection.Add((T)control);
            if (control.HasChildren)
                resultCollection.AddRange(GetControlsRec(control.Controls, resultCollection));
        }
        
        return resultCollection;
    }

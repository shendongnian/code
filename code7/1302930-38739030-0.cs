    public void OnLayerEvent(object sender, Rhino.DocObjects.Tables.LayerTableEventArgs e)
    {
        if (e.NewState.IsLocked)
        {
            var newLayerSettings = new Rhino.DocObjects.Layer();
            newLayerSettings.Name = e.Document.Layers[e.LayerIndex].Name;
            newLayerSettings.IsVisible = true;
            e.Document.Layers.Modify(newLayerSettings, e.LayerIndex, true);
        }
    }

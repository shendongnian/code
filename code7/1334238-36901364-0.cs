    /* Make a list of all feature classes. */
    List<ILayer> layers_list = new List<ILayer>();
    IMap map = get_map();
    IEnumLayer enumLayer = map.get_Layers(null, true);
    ILayer layer = null;
    while (layer = enumLayer.Next() != null) {
        // we're looking for a feature class only
        if (layer is IFeatureLayer) {
            try {
                IFeatureClass fclass = ((IFeatureLayer)layer).FeatureClass;
                IFeatureLayer featureLayer = (IFeatureLayer)layer;
                // Get the dataset and workspace of the feature class
                IDataset ds = (IDataset)fclass;
                IWorkspace ws = (IWorkspace)ds.Workspace;
                // Do something with the workspace, like getting the path or
                // whatever...
            } catch (Exception e) {
                MessageBox.Show("Layer ' " + layer.Name + "': \n\n" + e.Message);
            }
        }
    }

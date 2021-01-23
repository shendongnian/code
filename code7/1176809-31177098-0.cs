    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            MainWindow.logger.Debug("Entering: {0}", "MainWindow_Loaded");
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"Jofta\Analyzer\configs\AvalonDock.config");
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                XmlLayoutSerializer serializer = new XmlLayoutSerializer(this.dockingManager);
                serializer.LayoutSerializationCallback += this.Serializer_LayoutSerializationCallback;
                serializer.Deserialize(filePath);
            }
            MainWindow.logger.Debug("Exiting: {0}", "MainWindow_Loaded");
        }
        catch (Exception ex)
        {
            MainWindow.logger.Error("Exception in: {0}", "MainWindow_Loaded");
            MainWindow.logger.Error("Message: {0}", ex.Message);
        }
    }
    private void Serializer_LayoutSerializationCallback(object sender, LayoutSerializationCallbackEventArgs e)
    {
        try
        {
            MainWindow.logger.Debug("Entering: {0}", "serializer_LayoutSerializationCallback");
            if (e.Model.ContentId == ObjectExplorerViewModel.AnchorableContentId)
            {
                e.Content = Workspace.Instance.ObjectExplorer;
                return;
            }
            // ...
            // ...
            MainWindow.logger.Debug("Exiting: {0}", "serializer_LayoutSerializationCallback");
        }
        catch (Exception ex)
        {
            MainWindow.logger.Error("Exception in: {0}", "serializer_LayoutSerializationCallback");
            MainWindow.logger.Error("Message: {0}", ex.Message);
        }
    }

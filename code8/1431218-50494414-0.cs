    var layoutSerializer = new XmlLayoutSerializer(this.DockManager);
    layoutSerializer.LayoutSerializationCallback += layoutSerializer_LayoutSerializationCallback;
    protected virtual void layoutSerializer_LayoutSerializationCallback(object sender, LayoutSerializationCallbackEventArgs e)
        {
            try
            {
                var model = this.Docs.Union(this.Tools).FirstOrDefault(vm => vm.ContentId == e.Model.ContentId);
                if (model != null)
                {
                    e.Content = model;
                }
                else
                {
                    // Log load layout error info                    
                }
            }
            catch (Exception ex)
            {
                // Log load layout error info    
            }
        }

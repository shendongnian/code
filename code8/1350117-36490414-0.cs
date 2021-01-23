    if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview"))
    {
                    if (Windows.Foundation.Metadata.ApiInformation.IsMethodPresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview", "GetElementVisual"))
                    {
                        _compositor = new Windows.UI.Composition.Compositor();
                        _root = Windows.UI.Xaml.Hosting.ElementCompositionPreview.GetElementVisual(btn1);
                    }
                    else
                    {
                        //Do other things
                    }
    }

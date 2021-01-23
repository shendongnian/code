        private void Window_Loaded(object sender, RoutedEventArgs e) {
			InitDx12();
            CreateDx11Stuff();
            DxImage.SetPixelSize(1280, 720);
            DxImage.WindowOwner = (new System.Windows.Interop.WindowInteropHelper(this)).Handle;
            DxImage.OnRender += Render;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

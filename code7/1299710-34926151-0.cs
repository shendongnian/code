        MediaControl.ManipulationMode = ManipulationModes.Scale | ManipulationModes.TranslateX;
        private void MediaControl_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            MediaControl.Height = e.Delta.Scale * MediaControl.ActualHeight;
            MediaControl.Width = e.Delta.Scale * MediaControl.ActualWidth;
        }

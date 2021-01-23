        private void IlPanelOnLoad()
        {
            ...
            var plotCube = GetPlotCube();
            if (plotCube != null)
            {
                plotCube.MouseWheel += OnPlotCubeMouseWheelEvent;
            }
        }
        #region MouseWheel Zoom
        const float scaleFactor = 0.05f;  // 5% scaling, Adjust this to get faster/slower scaling
        const float WHEEL_DELTA = 120.0f; // One mouse wheel notch
        void OnPlotCubeMouseWheelEvent(object sender, ILMouseEventArgs mea)
        {
            if (mea.Clicks == 0) // Only when no buttons pressed at the same time
            {
                var plotCube = sender as ILPlotCube;
                if (plotCube != null)
                {
                    // + or - a scaleFactor change per wheel mouse notch
                    float zoomFactor = 1 - ((float)mea.Delta) / WHEEL_DELTA * scaleFactor;
                    ILLimits ilLimits = plotCube.Limits;
                    ApplyScaleFactor(zoomFactor, ilLimits);
                    ilPanel.Refresh();
                }
            }
            mea.Cancel = true; // Stop mouse wheel event default behaviour
        }
        private void ApplyScaleFactor(float zoomFactor, ILLimits ilLimits)
        {
            // delta here is nothing to do with wheel mouse delta
            float delta = ilLimits.WidthF * zoomFactor / 2f;
            ilLimits.XMin = ilLimits.CenterF.X - delta;
            ilLimits.XMax = ilLimits.CenterF.X + delta;
            delta = ilLimits.HeightF * zoomFactor / 2f;
            ilLimits.YMin = ilLimits.CenterF.Y - delta;
            ilLimits.YMax = ilLimits.CenterF.Y + delta;
        }
        private void ApplyScaleFactorHasWhitePatches(float zoomFactor, ILLimits ilLimits)
        {
            ilLimits.Update(ilLimits.CenterF, zoomFactor);
        }
        #endregion MouseWheel Zoom

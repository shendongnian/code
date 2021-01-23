    IntPtr DragableRegionNative = Native.CreateRectRgn(0, 0, 0, 0);
        void RegionsChangedCallback(DraggableRegion[] Regions)
        {
            Native.SetRectRgn(DragableRegionNative, 0, 0, 0, 0);
            if (Regions == null)
                return;
            foreach (var Region in Regions)
            {
                var RegionNative = Native.CreateRectRgn(
                    Region.X, Region.Y,
                    Region.X + Region.Width,
                    Region.Y + Region.Height);
                Native.CombineRgn(DragableRegionNative, DragableRegionNative, RegionNative,
                    Region.Draggable ? (int)Native.CombineRgnStyles.RGN_OR : (int)Native.CombineRgnStyles.RGN_DIFF);
                Native.DeleteObject(RegionNative);
            }
        }
        
        Point dragOffset = new Point();
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                dragOffset = this.PointToScreen(e.Location);
                dragOffset.X -= Location.X;
                dragOffset.Y -= Location.Y;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                Point newLocation = this.PointToScreen(e.Location);
                newLocation.X -= dragOffset.X;
                newLocation.Y -= dragOffset.Y;
                Location = newLocation;
            }
        }
        void chromewb_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (chromewb.IsBrowserInitialized)
            {
                ChromeWidgetMessageInterceptor.SetupLoop(chromewb, (m) =>
                {
                    if (m.Msg == (int)Native.WM.WM_LBUTTONDOWN)
                    {
                        var point = Native.ParsePoint(m.LParam.ToInt32());
                        if (Native.PtInRegion(DragableRegionNative, point.X, point.Y))
                            this.InvokeEx(() => Native.PostMessage(this.Handle, (uint)m.Msg, m.WParam, m.LParam));
                    }
                });
            }
        }

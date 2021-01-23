    private async void UpdateDx9Image()
        {
            if (Application.Current == null) return;
            await Application.Current?.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
            {
                if (DxImage.TryLock(new Duration(new TimeSpan(0, 0, 0, 0, 16))))
                {
                    DxImage.SetBackBuffer(D3DResourceType.IDirect3DSurface9, _Renderer.Resources.Dx9Surface.NativePointer, false);
                    DxImage.AddDirtyRect(new Int32Rect(0, 0, _Renderer.Resources.Dx9Surface.Description.Width, _Renderer.Resources.Dx9Surface.Description.Height));
                }
                DxImage.Unlock();
            }));
        }

    private void CreateWPFInteropFBO()
        {
            var desc = new Texture2DDescription {
                ArraySize = 1,
                BindFlags = BindFlags.RenderTarget,
                Format = SharpDX.DXGI.Format.B8G8R8A8_UNorm,
                Height = RenderTargetSize.Height,
                Width = RenderTargetSize.Width,
                MipLevels = 1,
                OptionFlags = ResourceOptionFlags.Shared,
                SampleDescription = new SharpDX.DXGI.SampleDescription(1, 0),
                Usage = ResourceUsage.Default
            };
            Dx11Texture?.Dispose();
            Dx11Texture = new Texture2D(_D3D11Device, desc);
            var ptr = Dx11Texture.NativePointer;
            var comobj = new ComObject(ptr);
            using (var dxgiRes = comobj.QueryInterface<SharpDX.DXGI.Resource>()) {
                var sharedHandle = dxgiRes.SharedHandle;
                var texture = new Texture(_D3D9Device, desc.Width, desc.Height, 1, SharpDX.Direct3D9.Usage.RenderTarget, SharpDX.Direct3D9.Format.A8R8G8B8, Pool.Default, ref sharedHandle);
                Dx9Surface?.Dispose();
                Dx9Surface = texture.GetSurfaceLevel(0);
            }
        }

        if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
        {
            bitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format32bppArgb);
        }
        var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        var ret = new SharpDX.Direct3D11.Texture2D(device, new SharpDX.Direct3D11.Texture2DDescription()
        {
            Width = bitmap.Width,
            Height = bitmap.Height,
            ArraySize = 1,
            BindFlags = SharpDX.Direct3D11.BindFlags.ShaderResource,
            Usage = SharpDX.Direct3D11.ResourceUsage.Immutable,
            CpuAccessFlags = SharpDX.Direct3D11.CpuAccessFlags.None,
            Format = SharpDX.DXGI.Format.B8G8R8A8_UNorm,
            MipLevels = 1,
            OptionFlags = SharpDX.Direct3D11.ResourceOptionFlags.None,
            SampleDescription = new SharpDX.DXGI.SampleDescription(1, 0),
        }, new SharpDX.DataRectangle(data.Scan0, data.Stride));
        bitmap.UnlockBits(data);
        return ret;

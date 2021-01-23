    Device.ImmediateContext.ClearRenderTargetView(this.m_RenderTargetView, Color4.Black);
        Texture2DDescription colordesc = new Texture2DDescription
        {
            BindFlags = BindFlags.ShaderResource,
            Format = m_PixelFormat,
            Width = iWidth,
            Height = iHeight,
            MipLevels = 1,
            SampleDescription = new SampleDescription(1, 0),
            Usage = ResourceUsage.Dynamic,
            OptionFlags = ResourceOptionFlags.None,
            CpuAccessFlags = CpuAccessFlags.Write,
            ArraySize = 1
        };
        Texture2D newFrameTexture = new Texture2D(this.Device, colordesc);
        DataStream dtStream = null;
        DataBox dBox = Device.ImmediateContext.MapSubresource(newFrameTexture, 0, MapMode.WriteDiscard, 0, out dtStream);
        if (dtStream != null)
        {
            int iRowPitch = dBox.RowPitch;
            for (int iHeightIndex = 0; iHeightIndex < iHeight; iHeightIndex++)
            {
                //Copy the image bytes to Texture
                dtStream.Position = iHeightIndex * iRowPitch;
                Marshal.Copy(decodedData, iHeightIndex * iWidth, new IntPtr(dtStream.DataPointer.ToInt64() + iHeightIndex * iRowPitch), iWidth);
            }
        }
        Device.ImmediateContext.UnmapSubresource(newFrameTexture, 0);
        Device.ImmediateContext.CopySubresourceRegion(newFrameTexture, 0, null, this.RenderTarget, 0);
        var shaderRescVw = new ShaderResourceView(this.Device, this.RenderTarget);
        Device.ImmediateContext.PixelShader.SetShaderResource(0, shaderRescVw);
        Device.ImmediateContext.Draw(6, 0);
        Device.ImmediateContext.Flush();
        this.D3DSurface.InvalidateD3DImage();
        Disposer.SafeDispose(ref newFrameTexture);

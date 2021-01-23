    private void Render(IntPtr surface, bool newSurface) {
			DoDx12Rendering();
			var unk = new ComObject(surface);
			var dxgiRes = unk.QueryInterface<SharpDX.DXGI.Resource>();
			var tempRes = D3D11Device.OpenSharedResource<SharpDX.Direct3D11.Resource>(dxgiRes.SharedHandle);
			var backBuffer = tempRes.QueryInterface<Texture2D>();
			var d3d11BackBuffer = D3D11BackBuffers[CurrentFrame];
			D3D11On12.AcquireWrappedResources(new[] { d3d11BackBuffer }, 1);
			D3D11Device.ImmediateContext.CopyResource(d3d11BackBuffer, backBuffer);
			D3D11Device.ImmediateContext.Flush();
			D3D11On12.ReleaseWrappedResources(new[] { d3d11BackBuffer }, 1);
        }

			SlimDX.Direct2D.Factory d2dFactory = new SlimDX.Direct2D.Factory(SlimDX.Direct2D.FactoryType.Multithreaded, SlimDX.Direct2D.DebugLevel.None);
			SlimDX.Direct2D.WindowRenderTarget d2dWindowRenderTarget = new SlimDX.Direct2D.WindowRenderTarget(d2dFactory, new SlimDX.Direct2D.WindowRenderTargetProperties() { Handle = targetControl.Handle, PixelSize = targetControl.Size, PresentOptions = SlimDX.Direct2D.PresentOptions.Immediately });
			d2dWindowRenderTarget.BeginDraw();
			d2dWindowRenderTarget.Clear(new SlimDX.Color4(Color.LightSteelBlue));
            d2dWindowRenderTarget.DrawRectangle(new SlimDX.Direct2D.SolidColorBrush(d2dWindowRenderTarget, new SlimDX.Color4(Color.Red)), new Rectangle(20,20, targetControl.Width-40, targetControl.Height-40));
			d2dWindowRenderTarget.EndDraw();

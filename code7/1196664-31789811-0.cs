    ...
    renderer.OnNewFrameEvent += new OnNewFrame(OnNewVideoFrame);
    }
    
    private void OnNewVideoFrame(IntPtr bitmapBuffer, int bitmapBufferLength)
    {
        FrameDispatcher.Instance.DispatchFrame("LocalVideo", bitmapBuffer, bitmapBufferLength);
    }

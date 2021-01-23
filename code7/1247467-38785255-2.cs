        private IntPtr _WndProc(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            WM message = (WM)uMsg;
            if (message == WM_TASKBARBUTTONCREATED)
            {
                _OnIsAttachedChanged(true);
                _isAttached = true;
                handled = false;
            }
            else
            {
                switch (message)
                {
                    case WM.COMMAND:
                        if (Utility.HIWORD(wParam.ToInt64()) == THUMBBUTTON.THBN_CLICKED)  <-----
                        {
                            int index = Utility.LOWORD(wParam.ToInt64());   <----
                            ThumbButtonInfos[index].InvokeClick();
                            handled = true;
                        }
                        break;
                    case WM.SIZE:
                        _UpdateThumbnailClipping(_isAttached);
                        handled = false;
                        break;
                }
            }
            return IntPtr.Zero;
        }

    using (Bitmap screenPixel = new Bitmap(1, 1))
                {
                    if (IsWindow(hWnd))
                    {
                        using (Graphics gdest = Graphics.FromImage(screenPixel))
                        {
                            using (Graphics gsrc = Graphics.FromHwnd(hWnd))
                            {
                                IntPtr hSrcDC = gsrc.GetHdc();
                                IntPtr hDestDC = gdest.GetHdc();
                                int retval = BitBlt(hDestDC, 0, 0, 1, 1, hSrcDC, p.X, p.Y, (int)CopyPixelOperation.SourceCopy);
                                gdest.ReleaseHdc();
                                gsrc.ReleaseHdc();
                                DeleteDC(hSrcDC);
                                DeleteDC(hDestDC);
                            }
                        }
                    }
                    
                    c = screenPixel.GetPixel(0, 0);
                }
                return c;

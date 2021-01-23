    var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(ExePath);
    var bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                                        sysicon.Handle,
                                        System.Windows.Int32Rect.Empty,
                                        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                            sysicon.Dispose();
                            bmpSrc.Freeze();
                            fileIcon = bmpSrc;

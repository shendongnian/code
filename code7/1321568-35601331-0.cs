       private Size oldSize;
                    protected override void OnResize(System.EventArgs e)
                    {
                        base.OnResize(e);
                        foreach (Control cnt in this.Controls)
                        {
                            ResizeAll(cnt, base.Size);
                        }
                        oldSize = base.Size;
                    }
                    private void ResizeAll(Control cnt, Size newSize)
                    {
                        int iWidth = newSize.Width - oldSize.Width;
                        cnt.Left += (cnt.Left * iWidth) / oldSize.Width;
                        cnt.Width += (cnt.Width * iWidth) / oldSize.Width;
            
                        int iHeight = newSize.Height - oldSize.Height;
                        cnt.Top += (cnt.Top * iHeight) / oldSize.Height;
                        cnt.Height += (cnt.Height * iHeight) / oldSize.Height;
                    }
     

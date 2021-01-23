        private void UpdateThumb()
        {
            if (thumb != IntPtr.Zero)
            {
                PSIZE size;
                DwmQueryThumbnailSourceSize(thumb, out size);
                DWM_THUMBNAIL_PROPERTIES props = new DWM_THUMBNAIL_PROPERTIES();
                props.fVisible = true;
                props.dwFlags = DWM_TNP_VISIBLE | DWM_TNP_RECTDESTINATION | DWM_TNP_OPACITY;
                props.opacity = (byte)opacity.Value;
                props.rcDestination = new Rect(image.Left, image.Top, image.Right, image.Bottom);
                if (size.x < image.Width)
                    props.rcDestination.Right = props.rcDestination.Left + size.x;
                if (size.y < image.Height)
                    props.rcDestination.Bottom = props.rcDestination.Top + size.y;
                
                DwmUpdateThumbnailProperties(thumb, ref props);
            }
        }

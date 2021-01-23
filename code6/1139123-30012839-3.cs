        /// <include file='doc\Bitmap.uex' path='docs/doc[@for="Bitmap.SetPixel"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Sets the color of the specified pixel in this <see cref='System.Drawing.Bitmap'/> .
        ///    </para>
        /// </devdoc>
        public void SetPixel(int x, int y, Color color) {
            if ((PixelFormat & PixelFormat.Indexed) != 0) {
                throw new InvalidOperationException(SR.GetString(SR.GdiplusCannotSetPixelFromIndexedPixelFormat));
            }
 
            if (x < 0 || x >= Width) {
                throw new ArgumentOutOfRangeException("x", SR.GetString(SR.ValidRangeX));
            }
 
            if (y < 0 || y >= Height) {
                throw new ArgumentOutOfRangeException("y", SR.GetString(SR.ValidRangeY));
            }
 
            int status = SafeNativeMethods.Gdip.GdipBitmapSetPixel(new HandleRef(this, nativeImage), x, y, color.ToArgb());
 
            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    ...
    private void HueRotateButton_Click(object sender, EventArgs e)
    {
        // Get the cosine and sine of the selected hue rotation angle
        var radians = Math.PI * (double)HueRotateAngleSelector.Value / 180.0;
        var cos = Math.Cos(radians);
        var sin = Math.Sin(radians);
        // Calculate the elements of the RGB transformation matrix
        var a00 = 0.213 + cos * 0.787 - sin * 0.213;
        var a01 = 0.213 - cos * 0.213 + sin * 0.143;
        var a02 = 0.213 - cos * 0.213 - sin * 0.787;
        var a10 = 0.715 - cos * 0.715 - sin * 0.715;
        var a11 = 0.715 + cos * 0.285 + sin * 0.140;
        var a12 = 0.715 - cos * 0.715 + sin * 0.715;
        var a20 = 0.072 - cos * 0.072 + sin * 0.928;
        var a21 = 0.072 - cos * 0.072 - sin * 0.283;
        var a22 = 0.072 + cos * 0.928 + sin * 0.072;
        // Get the current image from the picture box control, ...
        var bitmap = (Bitmap)HueRotatePictureBox.Image;
        var width = bitmap.Width;
        var height = bitmap.Height;
        // ... and open it for modification
        var bitmapData = bitmap.LockBits(
            new Rectangle(0, 0, width, height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppArgb);
        var scan0 = bitmapData.Scan0;
        var stride = bitmapData.Stride;
        // Copy the image pixels to a local byte array
        var length = height * stride;
        var bytes = new byte[length];
        Marshal.Copy(scan0, bytes, 0, length);
        // Loop over all pixels in the image
        for (var y = 0; y < height; y++)
        {
            var offset = stride * y;
            for (var x = 0; x < width; x++, offset += 4)
            {
                // Get the original RGB components for the individual pixel
                // (the alpha component should not be changed and is therefore ignored)
                double b = bytes[offset];
                double g = bytes[offset + 1];
                double r = bytes[offset + 2];
                // Apply the hue rotation transform
                var rr = Math.Max(0.0, Math.Min(255.0, r * a00 + g * a10 + b * a20));
                var gr = Math.Max(0.0, Math.Min(255.0, r * a01 + g * a11 + b * a21));
                var br = Math.Max(0.0, Math.Min(255.0, r * a02 + g * a12 + b * a22));
                // Update the RGB components
                bytes[offset] = (byte)br;
                bytes[offset + 1] = (byte)gr;
                bytes[offset + 2] = (byte)rr;
            }
        }
        // Bitmap editing is finished, transfer the updated byte array to the image pixels 
        // and "lock" the image again
        Marshal.Copy(bytes, 0, scan0, length);
        bitmap.UnlockBits(bitmapData);
        // Update the image in the picture box
        HueRotatePictureBox.Image = bitmap;
    }

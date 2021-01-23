    <Extension>
    Public Function ChangeColor(ByVal image As Image, ByVal oldColor As Color, ByVal newColor As Color)
        Dim newImage As Bitmap = New Bitmap(image.Width, image.Height, image.PixelFormat)
        Using g As Graphics = Graphics.FromImage(newImage)
            g.DrawImage(image, Point.Empty)
        End Using
        ' Lock the bitmap's bits.
        Dim rect As New Rectangle(0, 0, newImage.Width, newImage.Height)
        Dim bmpData As BitmapData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat)
        ' Get the address of the first line.
        Dim ptr As IntPtr = bmpData.Scan0
        ' Declare an array to hold the bytes of the bitmap. 
        Dim numBytes As Integer = (bmpData.Stride * newImage.Height)
        Dim rgbValues As Byte() = New Byte(numBytes - 1) {}
        ' Copy the RGB values into the array.
        Marshal.Copy(ptr, rgbValues, 0, numBytes)
        ' Manipulate the bitmap.
        For i As Integer = 0 To rgbValues.Length - 3 Step 3
            Dim testColor As Color = Color.FromArgb(rgbValues(i + 2), rgbValues(i + 1), rgbValues(i))
            If (testColor.ToArgb() = oldColor.ToArgb()) Then
                rgbValues(i) = newColor.B
                rgbValues(i + 1) = newColor.G
                rgbValues(i + 2) = newColor.R
            End If
        Next i
        ' Copy the RGB values back to the bitmap.
        Marshal.Copy(rgbValues, 0, ptr, numBytes)
        ' Unlock the bits.
        newImage.UnlockBits(bmpData)
        Return newImage
    End Function

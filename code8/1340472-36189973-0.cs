    Public Shared Function SaveAsThumbnailCropped(ByVal path As String, ByVal archivo As String, ByVal NewWidth As Integer, ByVal NewHeight As Integer) As String
        ' Declare two variables of type Integer named
        '    adjustedImageWidth and adjustedImageHeight.
        Dim adjustedImageWidth, adjustedImageHeight As Integer
        ' Declare a variable named theImage of type Image.
        Dim theImage As Image
        Dim ThumbFileName, extension As String, convertToGIF As Boolean = False
        If InStrRev(archivo, ".") > 0 Then
            extension = Mid(archivo, InStrRev(archivo, ".")).ToString.ToLower
            ThumbFileName = Mid(archivo, 1, InStrRev(archivo, ".") - 1) + "_tb" + Trim(NewWidth) + "x" + Trim(NewHeight) + extension
        Else
            extension = "" 'desconocida
            ThumbFileName = archivo + "_tb" + Trim(NewWidth) + "x" + Trim(NewHeight)
        End If
        If Not My.Computer.FileSystem.FileExists(path + "\" + ThumbFileName) And My.Computer.FileSystem.FileExists(path + "\" + archivo) Then
            ' Get an image object from the image file;
            '    assign the image object to the theImage variable.
            theImage = System.Drawing.Image.FromFile(path + "\" + archivo)
            If theImage.Height > NewHeight Or theImage.Width > NewWidth Then
                If theImage.Height * NewWidth / theImage.Width > NewHeight Then
                    ' tengo que reducir el alto
                    adjustedImageHeight = NewHeight
                    'keep ratio
                    adjustedImageWidth = theImage.Width * (adjustedImageHeight / theImage.Height)
                Else
                    adjustedImageWidth = NewWidth
                    'keep ratio
                    adjustedImageHeight = theImage.Height * (adjustedImageWidth / theImage.Width)
                End If
            Else
                'no hago nada porque la imagen es muy chica
                Return archivo
            End If
            Dim cropRect As Rectangle
            If adjustedImageHeight < NewHeight Or adjustedImageWidth > NewWidth Then
                'era muy apaisada tengo que croppear el centro
                adjustedImageHeight = NewHeight
                adjustedImageWidth = theImage.Width * (adjustedImageHeight / theImage.Height)
                Dim WidthSobrante = adjustedImageWidth - NewWidth
                cropRect = New Rectangle(WidthSobrante / 2, 0, NewWidth, NewHeight)
            ElseIf adjustedImageHeight > NewHeight Or adjustedImageWidth < NewWidth Then
                adjustedImageWidth = NewWidth
                adjustedImageHeight = theImage.Height * (adjustedImageWidth / theImage.Width)
                'quedo muy larga. Le cropeo el 25% de arriba del sobrante
                Dim HeightSobrante = adjustedImageHeight - NewHeight
                cropRect = New Rectangle(0, HeightSobrante / 4, NewWidth, NewHeight)
            Else
                cropRect = New Rectangle(0, 0, Math.Min(NewWidth, theImage.Width), Math.Min(NewHeight, theImage.Height))
            End If
            Dim Image As System.Drawing.Image = theImage
            Dim thumbnail As System.Drawing.Image = New Bitmap(adjustedImageWidth, adjustedImageHeight)
            Dim graphic As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(thumbnail)
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphic.SmoothingMode = SmoothingMode.HighQuality
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality
            graphic.CompositingQuality = CompositingQuality.HighQuality
            graphic.DrawImage(Image, 0, 0, adjustedImageWidth, adjustedImageHeight)
            Dim croppedThumbnail = cropImage(thumbnail, cropRect)
            If extension.Equals(".gif") Then
                Dim quantizer As ImageQuantization.OctreeQuantizer = New ImageQuantization.OctreeQuantizer(255, 8)
                Dim quantized As Bitmap = quantizer.Quantize(croppedThumbnail)
                quantized.Save(path + "\" + ThumbFileName, System.Drawing.Imaging.ImageFormat.Gif)
            ElseIf extension.Equals(".jpg") Or extension.Equals(".jpeg") Then
                'Create quality parameter
                Dim encoderParams As New EncoderParameters(1)
                Dim jpgCodec As ImageCodecInfo
                jpgCodec = GetImageCodec("image/jpeg")
                If Not jpgCodec Is Nothing Then
                    'Create quality parameter
                    Dim qParam As New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L)
                    encoderParams.Param(0) = qParam
                    croppedThumbnail.Save(path + "\" + ThumbFileName, jpgCodec, encoderParams)
                End If
            Else
                croppedThumbnail.Save(path + "\" + ThumbFileName)
            End If
            croppedThumbnail.Dispose()
            thumbnail.Dispose()
            Image.Dispose()
            graphic.Dispose()
        End If
        Return ThumbFileName
    End Function
    Private Shared Function cropImage(img As Image, cropArea As Rectangle) As Image
        Dim bmpImage = New Bitmap(img)
        Dim bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat)
        Return CType(bmpCrop, Image)
    End Function
    Private Shared Function GetImageCodec(ByVal mimeType As String) As ImageCodecInfo
        Dim codecs() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()
        For Each codec As ImageCodecInfo In codecs
            If codec.MimeType.Equals(mimeType, StringComparison.OrdinalIgnoreCase) Then
                Return codec
            End If
        Next
        Return Nothing
    End Function

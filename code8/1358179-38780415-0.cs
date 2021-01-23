            var imageStreamSource = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            var decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            var bitmapSource = decoder.Frames[0];
            // Draw the Image
            Image = bitmapSource.ToBitmap();
            using (var tiff = Tiff.Open(Filename, "r"))
            {
                Height = tiff.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                Width = tiff.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
                // see http://www.remotesensing.org/geotiff/spec/geotiff2.6.html#2.6.1
                var modelPixelScaleTag = tiff.GetField(TiffTag.GEOTIFF_MODELPIXELSCALETAG);
                var modelTiepointTag = tiff.GetField(TiffTag.GEOTIFF_MODELTIEPOINTTAG);
                //var modelTransformTag = tiff.GetField(TiffTag.GEOTIFF_MODELTRANSFORMATIONTAG);
                var modelPixelScale = modelPixelScaleTag[1].GetBytes();
                var ScaleX = BitConverter.ToDouble(modelPixelScale, 0);
                var ScaleY = BitConverter.ToDouble(modelPixelScale, 8) * -1;
                if (modelTiepointTag != null)
                {
                    var modelTransformation = modelTiepointTag[1].GetBytes();
                    var originLon = BitConverter.ToDouble(modelTransformation, 24);
                    var originLat = BitConverter.ToDouble(modelTransformation, 32);
                    // origin is the center of the pixel, so offset to
                    var startLat = originLat + (ScaleY / 2.0);
                    var startLon = originLon + (ScaleX / 2.0);
                    UpperLeft = new Position(startLat, startLon);
                    BottomRight = new Position(startLat + ScaleY * Height, startLon + ScaleX * Width);
                }
                //else if (modelTransformTag != null)
                //{
                // this is very complicated
                //}
                else
                {
                    throw new Exception("Couldn't understand the TIFF format");
                }
            }

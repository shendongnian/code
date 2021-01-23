    private static void DerotateIfRotatedWrongly(Image image)
        {
            if (image.PropertyIdList.Contains(0x0112))
            {
                var rotationValue = image.GetPropertyItem(0x0112).Value[0];
                switch (rotationValue)
                {
                    case 1: 
                        // landscape, do nothing
                        break;
                    case 8: 
                        // rotated 90 degrees right
                        // de-rotate:
                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case 3: 
                        // bottom is up
                        // de-rotate:
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 6: 
                        // rotated 90 degrees left
                        // de-rotate:
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
        }

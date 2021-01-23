    // prep containers for x and y vectors
    Image<Gray, float> velx = new Image<Gray, float>(newImage.Size);
    Image<Gray, float> vely = new Image<Gray, float>(newImage.Size);
    // use the Horn and Schunck dense optical flow algorithm.
    OpticalFlow.HS(oldImage, newImage, true, velx, vely, 0.1d, new MCvTermCriteria(100));
    // color each pixel
    Image<Hsv, Byte> coloredMotion = new Image<Hsv, Byte>(newImage.Size);
    for (int i = 0; i < coloredMotion.Width; i++)
    {
        for (int j = 0; j < coloredMotion.Height; j++)
        {
            // Pull the relevant intensities from the velx and vely matrices
            double velxHere = velx[j, i].Intensity;
            double velyHere = vely[j, i].Intensity;
            // Determine the color (i.e, the angle)
            double degrees = Math.Atan(velyHere / velxHere) / Math.PI * 90 + 45;
            if (velxHere < 0)
            {
                degrees += 90;
            }
            coloredMotion.Data[j, i, 0] = (Byte) degrees;
            coloredMotion.Data[j, i, 1] = 255;
            // Determine the intensity (i.e, the distance)
            double intensity = Math.Sqrt(velxHere * velxHere + velyHere * velyHere) * 10;
            coloredMotion.Data[j, i, 2] = (intensity > 255) ? 255 : intensity;
        }
    }
    // coloredMotion is now an image that shows intensity of motion by lightness
    // and direction by color.

    public void CircleAction(bool isClockWise)
    {
        if (!detectionActive)
        {
            return;
        }
        if (isClockWise)
        {
            myViewPort3D.CameraController.zoom(delta);
        }
        else
        {
            myViewPort3D.CameraController.zoom(-delta);
        }
    }

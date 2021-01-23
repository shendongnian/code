    private void PanGesture_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        try
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    {
                        _gestureX = e.TotalX;
                        _gestureY = e.TotalY;
                    }
                    break;
                case GestureStatus.Completed:
                    {
                        IsSwipe = true;
                        //Debug.WriteLine("{0}  {1}", _gestureX, _gestureY);
                        if (Math.Abs(_gestureX) > Math.Abs(_gestureY))
                        {
                            if (_gestureX > 0)
                            {
                                OnSwipeRight(null);
                            }
                            else
                            {
                                OnSwipeLeft(null);
                            }
                        }
                        else
                        {
                            if (_gestureY > 0)
                            {
                                OnSwipeDown(null);
                            }
                            else
                            {
                                OnSwipeUP(null);
                            }
                        }
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
        }
    }

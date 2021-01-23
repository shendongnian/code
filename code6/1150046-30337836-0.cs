     private void Page_OrientationChanged(object sender)
            {
                DisplayOrientations orientation = DisplayProperties.CurrentOrientation;
    
    switch (orientation )
                {
                    case DisplayOrientations.Landscape:
                        bla();
                        break;
                    case DisplayOrientations.LandscapeFlipped:
                        blabla();
                        break;    
                    case DisplayOrientations.Portrait:
                        MoreBla();
                        break;
                    case DisplayOrientations.PortraitFlipped:
                        MoreBlaBla();
                        break;
                }
            }

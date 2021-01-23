            if (e.PinchManipulation != null)
            {
                ImagesRoatate.ScaleX = e.PinchManipulation.CumulativeScale;
                ImagesRoatate.ScaleY = e.PinchManipulation.CumulativeScale;
                Point OriginalCenter = e.PinchManipulation.Original.Center;
                Point NewCenter = e.PinchManipulation.Current.Center;
                ImagesRoatate.TranslateX = NewCenter.X - OriginalCenter.X;
                ImagesRoatate.TranslateY = NewCenter.Y - OriginalCenter.Y;
                ImagesRoatate.Rotation = angleBetween2Lines(e.PinchManipulation.Current, e.PinchManipulation.Original);
                e.Handled = true;
            }
            else
            {
                ImagesRoatate.TranslateX +=  e.DeltaManipulation.Translation.X;
                ImagesRoatate.TranslateY += e.DeltaManipulation.Translation.Y;
            }
            System.Diagnostics.Debug.WriteLine("Images  Actual Width :- {0},Images  Actual Height :- {1}", Images.ActualWidth, Images.ActualHeight);
        }

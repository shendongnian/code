    if (((Editor)Element).HasBorder)
                    {
                        GradientDrawable gd = new GradientDrawable();
                        gd.SetColor(Android.Resource.Color.HoloRedDark);
                        gd.SetCornerRadius(4);
                        gd.SetStroke(2, Android.Graphics.Color.LightGray);
                        Control.SetBackground(gd);
                    }

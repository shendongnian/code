     #region Draw Bunker
                e.Graphics.DrawImage(WeighBin, WeighBin1Rect);
                e.Graphics.DrawImage(WeighBin, WeighBin2Rect);
                e.Graphics.DrawImage(getLargeLoaderGraphic(chuteAngle), SurgeBin1Rect);
                e.Graphics.DrawImage(getLargeLoaderGraphic(chuteAngle), SurgeBin2Rect);
                e.Graphics.DrawImage(SurgeBinHat, SurgeBinHatRect);
                SetTranslateTransformation(e, Chute1Rect.Width, Chute1Rect.X, Chute1Rect.Height, Chute1Rect.Y);
                if (increasing) //Chute is rotating out of the way
                {
                    SetRotationTransformation(e);
                    InvertTranslateTransformation(e, Chute1Rect.Width, Chute1Rect.X, Chute1Rect.Height, Chute1Rect.Y);
                    e.Graphics.DrawImage(ChuteRotating, Chute1Rect);
                }
                else    //Chute is rotating into load position
                {
                    if (chuteAngle == 0)    //Chute has rotated into load position
                    {
                        InvertTranslateTransformation(e, Chute1Rect.Width, Chute1Rect.X, Chute1Rect.Height, Chute1Rect.Y);
                        //Getting here means that the chute can be lifted & lowered because we are rotated down completely
                        if (lifting) //Chute is lifting out of the way
                        {
                            //Calculate Chute Slide position
                            Chute1SlideRect.Y -= chuteDistance;
                            Chute2SlideRect.Y -= chuteDistance;
                            e.Graphics.DrawImage(ChuteSlide, Chute1SlideRect);
                            e.Graphics.DrawImage(ChuteSlide, Chute2SlideRect);
                        }
                        else    //Chute is lifting into load position
                        {
                            //Calculate Chute Slide position
                            Chute1SlideRect.Y -= chuteDistance;
                            Chute2SlideRect.Y -= chuteDistance;
                            e.Graphics.DrawImage(ChuteSlide, Chute1SlideRect);
                            e.Graphics.DrawImage(ChuteSlide, Chute2SlideRect);
                            if (chuteDistance == 0)
                            {
                                if (opening) //Chute is in load position - start opening Gate
                                {
                                    //Draw the Chute's Gate image second to keep it on top of the Chute's Slide
                                    e.Graphics.DrawImage(ChuteSlideOpen, Chute1SlideOpenRect);
                                    e.Graphics.DrawImage(ChuteSlideOpen, Chute2SlideOpenRect);
                                    //Calculate Chute Gate position
                                    Chute1GateRect.X += gateDistance;
                                    Chute2GateRect.X += gateDistance;
                                    e.Graphics.DrawImage(ChuteGate, Chute1GateRect);
                                    e.Graphics.DrawImage(ChuteGate, Chute2GateRect);
                                }
                                else    //Begin closing Gate
                                {
                                    //Draw the Chute's Gate image second to keep it on top of the Chute's Slide
                                    e.Graphics.DrawImage(ChuteSlideOpen, Chute1SlideOpenRect);
                                    e.Graphics.DrawImage(ChuteSlideOpen, Chute2SlideOpenRect);
                                    //Calculate Chute Gate position
                                    Chute1GateRect.X += gateDistance;
                                    Chute2GateRect.X += gateDistance;
                                    e.Graphics.DrawImage(ChuteGate, Chute1GateRect);
                                    e.Graphics.DrawImage(ChuteGate, Chute2GateRect);
                                }
                            }
                        }
                        //Draw the Chute's Joint graphics AFTER the Chute's Slide so it's on top
                        e.Graphics.DrawImage(ChuteJoint, Chute1JointRect);
                        e.Graphics.DrawImage(ChuteJoint, Chute2JointRect);
                    }
                    else
                    {
                        SetRotationTransformation(e);
                        InvertTranslateTransformation(e, Chute1Rect.Width, Chute1Rect.X, Chute1Rect.Height, Chute1Rect.Y);
                        
                        e.Graphics.DrawImage(ChuteRotating, Chute1Rect);
                    }
                }
                #endregion
                #region Progress Bars
                //Position progress bar for bunker material levels  + (int)(ChuteHeight * 1.04)
                System1ProgressBar.Size = new Size(10, 45);
                System2ProgressBar.Size = new Size(10, 45);
                var progBar1X = -1 * Loader1Pos + (int)(ChuteWidth / 1.201);
                var progBar2X = Loader2Pos + (int)(ChuteWidth / 1.28);
                var progBarY = -1 * LoaderY - ChuteHeight / 21;
                System1ProgressBar.Location = new Point(progBar1X, progBarY);
                System2ProgressBar.Location = new Point(progBar2X, progBarY);
                System1ProgressBar.Maximum = 100;
                System1ProgressBar.Minimum = 0;
                System2ProgressBar.Maximum = 100;
                System2ProgressBar.Minimum = 0;
                if (!toppedOff)
                {
                    if (System1ProgressBar.Value == System1ProgressBar.Maximum)
                    {
                        toppedOff = true;
                    }
                    else
                    {
                        System1ProgressBar.Increment(+2);
                        System2ProgressBar.Increment(+2);
                    }
                }
                else
                {
                    if(System1ProgressBar.Value == System1ProgressBar.Minimum)
                    {
                        toppedOff = false;
                    }
                    else
                    {
                        System1ProgressBar.Increment(-2);
                        System2ProgressBar.Increment(-2);
                    }
                }
                #endregion
                InvertRotationTransformation(e, Chute1Rect.Width, Chute1Rect.X, Chute1Rect.Height, Chute1Rect.Y);
    //NOW we can start drawing out trains and they don't flip everywhere - the above //method being called in this spot is what corrects that problem

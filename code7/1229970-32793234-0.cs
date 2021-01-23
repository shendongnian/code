                        Rectangle newFaceRect = new Rectangle();
                        newFaceRect.Location = f.Location;
                        newFaceRect.Y = (int)(f.Y - face.Height / 4);
                        newFaceRect.X = (int)(f.X - face.Width / 4);
                        newFaceRect.Height = (int)(f.Height * 1.5);
                        newFaceRect.Width = (int)(f.Width * 1.5);
                        currentFrame.Draw(newFaceRect, new Bgr(Color.Black), 2);

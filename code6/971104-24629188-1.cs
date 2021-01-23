         if (OnlineTrainList.Count == 0) return;
            if(map!=null) map.Dispose();
            map = new Bitmap(pictureBoxonlineTrain.Size.Width, pictureBoxonlineTrain.Size.Height);
            using (Graphics graph = Graphics.FromImage(map))
            {
                foreach (TimeTable t in OnlineTrainList.ToList())
                {
                    Rectangle rectTrainState = new Rectangle(t.XTrainLocation.Value - 3,
                                                              t.YTrainLocation.Value - 3,
                                                              15, 15);
                    graph.FillRectangle(RedBrush, rectTrainState);
                    graph.DrawString(t.TrainId.ToString(), pictureBoxonlineTrain.Font, Brushes.White,
                                     t.XTrainLocation.Value - 3, t.YTrainLocation.Value - 3);                 
                }
            }
            if (pictureBoxonlineTrain.Image != null) pictureBoxonlineTrain.Image.Dispose();
            pictureBoxonlineTrain.Image = map;

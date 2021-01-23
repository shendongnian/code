       if (OnlineTrainList.Count == 0) return;
       Bitmap map = new Bitmap(pictureBoxonlineTrain.Size.Width, pictureBoxonlineTrain.Size.Height))
       using (Graphics graph = Graphics.FromImage(map)) {
           foreach (TimeTable t in OnlineTrainList.ToList()) {
               Rectangle rectTrainState = new Rectangle(...);
               graph.FillRectangle(RedBrush, rectTrainState);
               graph.DrawString(...);
           }
       }
       if (pictureBoxonlineTrain.Image != null) pictureBoxonlineTrain.Image.Dispose();
       pictureBoxonlineTrain.Image = map;

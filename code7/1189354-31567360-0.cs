    <ListBox ItemsSource="{Binding Path=ImagesCollection, IsAsync=True}" SelectedIndex="0" ScrollViewer.HorizontalScrollBarVisibility="Disabled">
       <ListBox.ItemsPanel>
          <ItemsPanelTemplate>
               <WrapPanel IsItemsHost="True" />
          </ItemsPanelTemplate>
       </ListBox.ItemsPanel>
       <ListBox.ItemTemplate>
           <DataTemplate>
              <Image Width="150" Height="150"  Source="{Binding}" />
           </DataTemplate>
       </ListBox.ItemTemplate>
    </ListBox>
    private void LoadImageProgress(object sender, ProgressChangedEventArgs e) {
			if (e.UserState != null && e.UserState is BitmapImage) {
				ImagesCollection.Add((BitmapImage)e.UserState);
			}
		}
		private void LoadImageThread(object sender, DoWorkEventArgs e) {
			string imagePath = Config.GetValue("ImagePath");
			if (!Directory.Exists(imagePath)) return;
			string[] files = Directory.GetFiles(imagePath);
			foreach (var file in files) {
				if (file.EndsWith(".jpg") || file.EndsWith(".png")) {
					var img = new Bitmap(file);
					float scale = Math.Min(150 / (float)img.Width, 150 / (float)img.Height);
					var bmp = new Bitmap(150, 150);
					var graph = Graphics.FromImage(bmp);
					var scaleWidth = (int)(img.Width * scale);
					var scaleHeight = (int)(img.Height * scale);
					graph.DrawImage(img, new System.Drawing.Rectangle((150 - scaleWidth) / 2, (150 - scaleHeight) / 2, scaleWidth, scaleHeight));
					BitmapImage retImg = new BitmapImage();
                    using (MemoryStream mem = new MemoryStream()) {
						bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
						mem.Position = 0;
						retImg.BeginInit();
						retImg.StreamSource = mem;
						retImg.CacheOption = BitmapCacheOption.OnLoad;
						retImg.EndInit();
						retImg.Freeze();
					}
					mThread.ReportProgress(0, retImg);
					if (mThread.CancellationPending) return;
					//Thread.Sleep(1000);
				}
			}
		}

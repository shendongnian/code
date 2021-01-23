            // Bind Buttons and Grid Cells
            int j = 0;
            var imgList = Randomizer();
            for (var i = 0; i < 16; i++)
            {
                if (i % 4 != _xPos || _yPos != i / 4)
                {
                    //Add image in a button
                    var bitmapImage = new BitmapImage();
                    var bitmap = imgList[j];
                    using (var memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    var image = new System.Windows.Controls.Image
                    {
                        Source = bitmapImage,
                        Stretch = Stretch.None
                    };
                    var currentstack = StackPanels[j];
                    currentstack.Orientation = Orientation.Horizontal;
                    currentstack.Children.Add(image);
                    Buttons[j].Content = currentstack;
                    
                    Buttons[j].Click += Button_Click;
                    Grid.SetColumn(Buttons[j], i % 4);
                    Grid.SetRow(Buttons[j], i / 4);
                    dynamicGrid.Children.Add(Buttons[j]);
                    j++;
                }
            }

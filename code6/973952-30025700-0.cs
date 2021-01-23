                        if (fill != null)
                        {
                            // We've now got the file. Do something with it.
                            var stream = await fill.OpenAsync(Windows.Storage.FileAccessMode.Read);
                            //var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                            //await bitmapImage.SetSourceAsync(stream);
                            bit.SetSource(stream);
                            imgTeste.Source = bit;
                            pvMestre.SelectedIndex = 1;
                        }
                        else
                        {
                            //OutputTextBlock.Text = "The operation may have been cancelled.";
                        }

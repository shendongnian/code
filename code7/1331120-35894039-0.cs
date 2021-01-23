			using (var ms = new MemoryStream(b))
			{
				using (Bitmap bmp = new Bitmap(ms))
				using (Bitmap thumbnail = bmp)
				{
					Rectangle rect = new Rectangle(5, 5, 10, 10);
					if (bmp.Width > bmp.Height)
						thumbnail = bmp.Clone(rect, bmp.PixelFormat);
					else if (bmp.Height > bmp.Width)
						thumbnail = bmp.Clone(new Rectangle((bmp.Height / 2) - (bmp.Width / 2), 0, bmp.Width, bmp.Width), bmp.PixelFormat);
					byte[] bmpArray = new byte[0];
					using (var ms = new MemoryStream())
					{
						finalCrop.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
						ms.Close();
						bmpArray = ms.ToArray();
					}
					var name = "Thumbnail_" + parentImageName;
					RepositoryFactory.AzureStorageRepository.SaveThumbnail(bmpArray, name, "jpg/image", CurrentUser.UserOrganization.Organization.Id);
					return BaseBlobUrl + "thumbnails/" + name;
				}
			}

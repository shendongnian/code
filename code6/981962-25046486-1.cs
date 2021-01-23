		[HttpPost]
		public string UploadOriginalImage(HttpPostedFileBase img)
		{
			string folder = Server.MapPath("~/Temp");
			string extension = Path.GetExtension(img.FileName);
			string pic = System.IO.Path.GetFileName(Guid.NewGuid().ToString());
			var tempPath = Path.ChangeExtension(pic, extension);
			string tempFilePath = System.IO.Path.Combine(folder, tempPath);
			img.SaveAs(tempFilePath);
			var image = System.Drawing.Image.FromFile(tempFilePath);
			var result = new 
			{
				status = "success",
				width = image.Width,
				height = image.Height,
				url = "../Temp/" + tempPath
			};
			return JsonConvert.SerializeObject(result);
		}
		[HttpPost]
		public string CroppedImage(string imgUrl, int imgInitW, int imgInitH, double imgW, double imgH, int imgY1, int imgX1, int cropH, int cropW)
		{
			var originalFilePath = Server.MapPath(imgUrl);
			var fileName = CropImage(originalFilePath, imgInitW, imgInitH, (int)imgW, (int)imgH, imgY1, imgX1, cropH, cropW);
			var result = new
			{
				status="success",
				url="../Cropped/" + fileName
			};
			return JsonConvert.SerializeObject(result);
		}
		private string CropImage(string originalFilePath, int origW, int origH, int targetW, int targetH, int cropStartY, int cropStartX, int cropW, int cropH)
		{
			var originalImage = Image.FromFile(originalFilePath);
			var resizedOriginalImage = new Bitmap(originalImage, targetW, targetH);
			var targetImage = new Bitmap(cropW, cropH);
			using (var g = Graphics.FromImage(targetImage))
			{
				g.DrawImage(resizedOriginalImage, new Rectangle(0, 0, cropW, cropH), new Rectangle(cropStartX, cropStartY, cropW, cropH), GraphicsUnit.Pixel);
			}
			string fileName = Path.GetFileName(originalFilePath);
			var folder = Server.MapPath("~/Cropped");
			string croppedPath = Path.Combine(folder, fileName);
			targetImage.Save(croppedPath);
			return fileName;
		}

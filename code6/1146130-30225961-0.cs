    async Task<WriteableBitmap> ConstructPageAsync()
        {
            var size = Document.GetPageSize(PageNumber);
            var width = (int)(size.X * ZoomFactor);
            var height = (int)(size.Y * ZoomFactor);
            var image = new WriteableBitmap(IsDoublePage ? width * 2 : width, height);
            IBuffer buf = new Buffer(image.PixelBuffer.Capacity);
            buf.Length = image.PixelBuffer.Length;
            if (IsDoublePage)
            {
                await Task.Run(() => Document.DrawFirtPageConcurrent(PageNumber, buf, width, height));
                await Task.Run(() => Document.DrawSecondPageConcurrent(PageNumber + 1, buf, width, height));
            }
            else
            {
                Document.DrawPage(PageNumber, buf, 0, 0, width, height, false);
            }
            // copy the buffer to the WriteableBitmap ( UI Thread )
            using (var stream = buf.AsStream())
            {
                await stream.CopyToAsync(image.PixelBuffer.AsStream());
            }
            return image;
        }

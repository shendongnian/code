                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            using (Stream imageStream = new MemoryStream(resizedImage))
            {
                using (Image scaleImage = Image.FromStream(imageStream))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        scaleImage.Save(ms, ImageFormat.Jpeg);
                        result.Content = new StreamContent(ms);
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    }
                }
            }
            return result;

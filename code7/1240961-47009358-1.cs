        private static async void DownloadFile(string fileId, string path)
        {
            try
            {
                var file = await Bot.GetFileAsync(fileId);
                using (var saveImageStream = new FileStream(path, FileMode.Create))
                {
                    await file.FileStream.CopyToAsync(saveImageStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error downloading: " + ex.Message);
            }
        }

     public class PhotoFactory
    {
        [...]
        public Photo CreatePhotoObject(FileInfo file)
        {
            string comment;
            string dateString;
            DateTime date;
            int year = 0;
            string filename = file.FullName;
            string path = selectedFolder + @"\" + filename;
            string photoname = file.Name;
            GetCommentDate(file.FullName, out comment, out dateString);
            if (dateString != null)
            {
                date = DateTime.Parse(dateString).Date;
                dateString = date.ToShortDateString();
                year = date.Year;
            }
            return new Photo(year, comment, filename, photoname, dateString);
        }
        private void GetCommentDate(string filepath, out string comment, out 
                                    string dateString)
        {
            using (FileStream fileIn = new FileStream(filepath, FileMode.Open, 
                   FileAccess.Read, FileShare.Read))
            {
                BitmapSource source = BitmapFrame.Create(fileIn);
                BitmapMetadata metadata = (BitmapMetadata)source.Metadata;
                comment = metadata.Comment;
                dateString = metadata.DateTaken;
            }
        }
    }

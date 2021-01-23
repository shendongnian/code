      public void ChangeDateTaken(string path)
        {
            Image theImage = new Bitmap(path);
            PropertyItem[] propItems = theImage.PropertyItems;
            Encoding _Encoding = Encoding.UTF8;
            var DataTakenProperty1 = propItems.Where(a => a.Id.ToString("x") == "9004").FirstOrDefault();
            var DataTakenProperty2 = propItems.Where(a => a.Id.ToString("x") == "9003").FirstOrDefault();
            string originalDateString = _Encoding.GetString(DataTakenProperty1.Value);
            originalDateString = originalDateString.Remove(originalDateString.Length - 1);
            DateTime originalDate = DateTime.ParseExact(originalDateString, "yyyy:MM:dd HH:mm:ss", null);
            originalDate = originalDate.AddHours(-7);
            DataTakenProperty1.Value = _Encoding.GetBytes(originalDate.ToString("yyyy:MM:dd HH:mm:ss") + '\0');
            DataTakenProperty2.Value = _Encoding.GetBytes(originalDate.ToString("yyyy:MM:dd HH:mm:ss") + '\0');
            theImage.SetPropertyItem(DataTakenProperty1);
            theImage.SetPropertyItem(DataTakenProperty2);
            string new_path = System.IO.Path.GetDirectoryName(path) + "\\_" + System.IO.Path.GetFileName(path);
            theImage.Save(new_path);
        }

    public async Task<string> CreateNewSlider(Slider slider, HttpPostedFileBase file)
    {
        string pic = null;
        if (file != null)
        {
            pic = System.IO.Path.GetFileName(file.FileName);
            string path = System.IO.Path.Combine(
                                   HostingEnvironment.MapPath("~/Content/images/slider"), pic);
            file.SaveAs(path);
            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                byte[] array = ms.GetBuffer();
            }
        }
        var createnewslider = new Slider
        {
            Alt = slider.Alt,
            CreationDate = slider.CreationDate,
            Description = slider.Description,
            IsVisible = slider.IsVisible,
            Order = slider.Order,
            Subtitle = slider.Subtitle,
            Title = slider.Title,
            VideoLink = slider.VideoLink,
            Image = pic // I can´t access to pic variable 
        };
        db.SlidersList.Add(createnewslider);
        await db.SaveChangesAsync();
        return "Slider Photo " + file + "has been created";
    }

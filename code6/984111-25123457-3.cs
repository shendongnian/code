        public void GetProfileImage(int? id)
        {
            var data = _companyService.GetProfileImage(id);
            if (data == null)
                return;
            var image = WebImageFactory.Get(data).ResizeMaxPreserveTransparency(250, 250);
            image.Write();
        }

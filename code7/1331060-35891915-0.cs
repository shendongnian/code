        if (db.RepresentativeImages.Any(x => x.RepresentativeId == rep.Id))
        {
            RepresentativeImages repImage = (from x in db.RepresentativeImages
                                             where x.RepresentativeId == rep.Id
                                             select x).First();
            repImage.Image = repView.Image;
            db.RepresentativeImages.Attach(repImage);
            var entryImage = db.Entry(repImage);
            entryImage.State = EntityState.Modified;
        }
        else
        {
            var repImage = new RepresentativeImages
            {
                Image = repView.Image,
                RepresentativeId = rep.Id
            };
            db.RepresentativeImages.Attach(repImage);
            db.RepresentativeImages.Add(repImage);
        }

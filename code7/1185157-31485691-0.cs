    // Remove previous formats
    foreach (ClubNewsFormat previousClubNewsFormats in clubNewsFormats)
        {
             db.ClubNewsFormats.Remove(previousClubNewsFormats);
        }
        // Add new club news formats
    foreach (ClubNewsFormatsViewModel clubNewsFormat in viewModel.ClubNewsFormats.Where(c => c.selected == true))
        {
             var newClubNewsFormat = new ClubNewsFormat { ClubId = club.ClubId, NewsFormatId = clubNewsFormat.NewsFormatId, Discount = clubNewsFormat.Discount };
             db.ClubNewsFormats.Add(newClubNewsFormat);
         }

     List<StudentBanDisplayViewModel> BanList = theData
              .Select(viewModel => new StudentBanDisplayViewModel
              {
                  ID = viewModel.ID,
                  UserID = viewModel.UserID,
                  StartBan = viewModel.StartBan,
                  EndBan = viewModel.EndBan
              }).Where(b => b.EndBan > DateTime.Today)
                .DistinctBy(s => new {s.UserID}).ToList();

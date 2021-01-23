     List<MaintenanceCheckListModel> checklist = db.checklists.Select( s => new MaintenanceCheckListModel()
        {
            FirstMonth = check.FirstMonth,
            SecondMonth = check.SecondMonth,
            ThirdMonth = check.ThirdMonth,
            FourthMonth = check.FourthMonth,
            FifthMonth = check.FifthMonth,
            SixthMonth = check.SixthMonth,
            SeventhMonth = check.SeventhMonth,
            EighthMonth = check.EighthMonth,
            NinethMonth = check.NinethMonth ,
            TenthMonth = check.TenthMonth,
            EleventhMonth = check.EleventhMonth,
            TwelvethMonth = check.TwelvethMonth
        }).ToList();

        Dfe = "School-1-" + dummySupplierId.ToString("000000"),
        SchoolSearchResult = new SchoolResult
        {
            SupplierId = dummySupplierId,
            SchoolName = "SchoolName" + dummySupplierId.ToString("000000"),         
            CreateDate = new DateTime(),
            Pupils = 123            
        }
        ,
        PupilSearchResult = new List<PupilResult>
        {
            new PupilResult
            {
                SupplierId = dummySupplierId,                    
                FirstName = "FirstName - Pupil-1-" + dummySupplierId.ToString("000000"),
                LastName = "LastName - Pupil-1-" + dummySupplierId.ToString("000000")
            },
            new PupilResult
            {
                SupplierId = dummySupplierId,
                FirstName = "FirstName - Pupil-2-" + dummySupplierId.ToString("000000"),
                LastName = "LastName - Pupil-2-" + dummySupplierId.ToString("000000")
            }
        }
    }).Take(2).ToList();

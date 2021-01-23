    var trainingStatusReport =
        from trainingTeacher in db.TRAINING_TEACHER
        group trainingTeacher by trainingTeacher.Teacher.Institute into instituteGroup
        let institute = instituteGroup.Select(t => t.Teacher.Institute).FirstOrDefault()
        select new TRAINING_STATUS_VIEW_MODEL
        {
            countMale = instituteGroup.Count(t => t.Teacher.Gender == Male),
            countFemail = instituteGroup.Count(t => t.Teacher.Gender == Femail),
            ZONE = institute.SubDistrict.District.Zone,
            DISTRICT = institute.SubDistrict.District,
            SUBDISTRICT = institute.SubDistrict,
            INSTITUTE = institute
        };

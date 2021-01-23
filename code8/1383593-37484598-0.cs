      public static IQueryable<ExamTimeSlot> WhereNameThisWhateverYouWant(IQueryable<ExamTimeSlot> Source, List<Guid> drivingSchoolIds)
      {
           var FirstFilter = GetFreeSpotCountFor(drivingSchoolIds);
           var SecondFilter = GetExamTimeSlotsWithFreeSpotsFor(drivingSchoolIds);
           return Source
                  .Where(FirstFilter)
                  .Where(SecondFilter);                   
      }

      public static IQueryable<ExamTimeSlot> WhereExamTimeSlotsWithFreeSpotsFor (IQueryable<ExamTimeSlot> Source, List<Guid> drivingSchoolIds)
      {
           var FirstFilter = GetFreeSpotCountFor(drivingSchoolIds);
           var SecondFilter = GetExamTimeSlotsWithFreeSpotsFor(drivingSchoolIds);
           return Source
                  .Where(FirstFilter)
                  .Where(SecondFilter);                   
      }

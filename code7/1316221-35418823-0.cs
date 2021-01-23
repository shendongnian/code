    public Diary ReturnDiaryById(int id)
    {
     using(var context = new DiaryContext())
     {
      var returnDiary = context.Diary.AsNoTracking().Include(a => a.Appointments)
                               .FirstOrDefault(d => d.Id == id);
    
      if (returnDiary != null)
      {
       returnDiary.Appointments = returnDiary.Appointments.OrderBy(c => c.Office.ToString()).ToList();
      } 
    
      return returnDiary ;
    }

    class Organizer {
      public IList<Workshop> Workshops { get; } = new List<Workshop>();
      public IList<Student> Students { get; } = new List<Student>();
      public IList<Round> Rounds { get; } = new List<Round>();
      public void Add(Workshop workshop) {
        if (workshop == null || Workshops.Contains(workshop)) {
          return;
        }
        Workshops.Add( workshop );
      }
      public void Add(Student student) {
        if (student == null || Students.Contains(student)) {
          return;
        }
        Students.Add( student );
      }
      public void Add(Round round) {
        if (round == null) {
          throw new ArgumentException( "Round should be set!" );
        }
        if (round.Workshop == null) {
          throw new ArgumentException( "Round.Workshop must be set!" );
        }
        Rounds.Add( round );
        Add( round.Workshop );
      }
      public IList<Subscription> CreateSubscriptionsList(bool enableAverageAttendees = true) {
        IList<Subscription> results = new List<Subscription>();
        int totalRoomAvailable = Rounds.Sum( round => round.AvailableSpace ) / Workshops.Count;
        int totalUniqueRounds = Rounds.GroupBy( round => round.StartsAt.ToShortDateString() + round.EndsAt.ToShortDateString() ).Count();
        int averageStudentsPerRoundCount = (int)Math.Floor((totalRoomAvailable - (Students.Count * totalUniqueRounds)) / (double)Workshops.Count);
        // per round
        foreach ( var round in Rounds ) {
          // get all the students, with the nr of courses they are enlisted with already
          // and sort by ascending
          var additions = (from student in Students
                          select new { Student = student, CourseCount = results.Count( i => i.Student.Equals( student ) ) })
                          .OrderBy(i => i.CourseCount);
          // check how many should be added in this round
          int count = !enableAverageAttendees ? round.AvailableSpace : (averageStudentsPerRoundCount > 0 ? averageStudentsPerRoundCount : round.AvailableSpace + Math.Abs(averageStudentsPerRoundCount));
          // add all that don't attend a course at the same time, or did this course already
          foreach (var addition in additions ) {
            if (results.Any(subscription => subscription.Student.Equals(addition.Student) 
                && (round.Workshop.Equals(subscription.Round.Workshop) 
                  || (round.StartsAt >= subscription.Round.StartsAt && round.EndsAt <= subscription.Round.EndsAt))
                )) {
              continue;
            }
            results.Add( new Subscription() { Round = round, Student = addition.Student } );
            count--;
            if (count <= 0) {
              break;
            }
          }
        }
        return results;
      }
    }

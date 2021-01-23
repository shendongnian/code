      ParticipantComparer theObject = new ParticipantComparer();
    
      if (typeof(IEqualityCustomComparer<Participant, ParticipantEntity>).IsInstanceOfType(theObject))
                {
                    Console.WriteLine("Assignable");
                }

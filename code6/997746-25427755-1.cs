    object[] visits_balance = new object[visitIdArray.Length];
    for(Int32 i = 0; i < visitIdArray.Length; i++)
    {
       Int32 total_visits;
       for(Int32 j = 0; j < currentCycleArray.Length; j++)
       {
          var visit = (CurrentVisit)currentCycleArray[j]; // Cast to CurrentVisit
          if(visit.visits_id == visitIdArray[i].visits_id)
          {
              total_visits = visit.total_visits;
          }
       }
    }

    if (!Board.Any(i => i.PartyCode == party.PartyCode.Trim()))
    {
          var newPartyResult = new OverallPartyResults()
          {
                 PartyCode = party.PartyCode.Trim(),
                 NumberOfSeats = seatNumber 
    
          };
          Board.Add(newPartyResult);
    }

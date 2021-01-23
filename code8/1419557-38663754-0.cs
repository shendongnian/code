    [DelimitedRecord(",")]
    public class FlashCardCsvRow
    {
         public string Front;
         public string Back;
         public string CardDifficulty;
    }
    var flashcards = new List<FlashCard>(); // your class above
    // populate flashcards however you like
    var csvRows = flashCards.Select(x =>
      new FlashCardCsvRow() 
         {
             Front = x.Front,
             Back = x.Back,
             CardDifficulty = x.CardDifficulty.ToString();
         });
    var engine = new FileHelperEngine<FlashCardCsvRow>();
    engine.WriteFile("Output.Txt", csvRows);
    

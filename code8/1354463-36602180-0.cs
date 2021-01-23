    public class HumanPlayer: IPlayer
    {
      private readonly IGui gui;
      public HumanPlayer(IGui gui)
      {
        this.gui = gui;
      }
      public int PickCardToDiscard()
      {
        return gui.AskForCardSelection("Pick a card to discard.");
      }
    }
    public class StupidPlayer: IPlayer
    {
      public int PickCardToDiscard()
      {
        return 42; // Feeling lucky
      }
    }

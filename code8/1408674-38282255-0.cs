    public class Dice
    {
        public int Value { get; set; }
        public BitmapImage sideToDisplay { get; set; }
    
        public void SetNewValue(List<BitmapImage> imageList, int diceValue)
        {
            Value = diceValue;
            sideToDisplay = imageList[Value - 1];
        }
    }
    
    and in the UpdateLogic 
    
        private void UpdateLogic()
        {
            Random rnd = new Random();
            foreach (Dice dice in dm.AllDices)
            {
                dice.SetNewValue(sidesToDisplay, rnd.Next(1,7));
            }
            ....
        }

	public class FoodOrder
	{
		public List<String> SpecialInstructions{get;set;}
		public void AddSpecialInstruction(string instruction)
		{
			SpecialInstructions.Add(instruction);
			SpecialInstructionsChanged?.Invoke(this,EventArgs.Empty);
		}
		public event EventHandler SpecialInstructionsChanged;
	}

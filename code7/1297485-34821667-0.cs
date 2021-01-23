    public override string GetInstructions()
        {
            PizzaGUI.Message("I am here!");
            string instructionLine;
            string qty = this.GetIngredientQuantity().ToString();
            string unit = this.GetIngredientUnit();
            string name = this.GetIngredientName();
            instructionLine = string.Format("Apply {0} {1} of {2} to the pizza.\n", qty, unit, name);
            return instructionLine;
        }

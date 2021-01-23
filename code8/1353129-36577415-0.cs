    bool isLastCalledTake = false;
    protected override void Update (GameTime gameTime)
    {
        //whtever are your first steps in update...
        if(/*user clicked on table logic here*/)
        {
            if(/*left button is clicked logic here*/)
            {
                if(isLastCalledTake)
                {
                    isLastCalledTake = false;
                    Drop();
                }
                else
                {
                    isLastCalledTake = true;
                    Take();
                }
            }
        }
    }
And so, when you Take(), you should chek if there is anything to take, is the right color figure taken, etc, and when you Drop(), check if the figure is dropped on the table, on the posible place, on the other figure, etc.<br>

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

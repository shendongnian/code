    //This method must return true if the current GridItem and the passed as parameter are the same
    public bool Equals(GridItem gridItem)
    {
        //What does a GridItem to be the same than other?
        //If it's just Ordernummer, as easy like:
        return this.Ordernummer == gridItem.Ordernummer;
    }

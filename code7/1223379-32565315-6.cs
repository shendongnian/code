    class GridItem : IEquatable<GridItem>
        {
            public int Ordernummer { get; set; }
            public int Bonnummer { get; set; }
            public int Volgnummer { get; set; }
            public string Bewerking { get; set; }
        
            //This method must return true if the current GridItem and the passed as parameter are the same
            public bool Equals(GridItem gridItem)
            {
                //What does a GridItem to be the same than other?
                //If it's just Ordernummer, as easy like:
                return this.Ordernummer == gridItem.Ordernummer;
            }
        }

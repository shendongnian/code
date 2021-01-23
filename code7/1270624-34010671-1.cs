            internal static Beer Beer
            {
                get { return beer; }
                set 
                { 
                    beersList.Add(value);
                    beer = value; 
                }
            }

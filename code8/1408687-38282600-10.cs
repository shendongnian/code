    static List<int> ATM( int value )
    {
        List<int> exchangeCoins = new List<int>();
        if ( value != 0 )
        {
            exchangeCoins.Add( value / 2 );
            exchangeCoins.Add( value / 3 );
            exchangeCoins.Add( value / 4 );
            // recursive call on the three items
            foreach ( var item in exchangeCoins.ToArray() )
            {
                exchangeCoins.AddRange( ATM( item ) );
            }
        }
        return exchangeCoins;
    }

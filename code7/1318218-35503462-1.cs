        static void Main( string[] args )
        {
            List<string> theAlreadyInUseNames = new List<string>();
            theAlreadyInUseNames.Add( "aName" );
            theAlreadyInUseNames.Add( "aName_1" );
            theAlreadyInUseNames.Add( "aName_2" );
            theAlreadyInUseNames.Add( "aName_3" );
            theAlreadyInUseNames.Add( "aName_4" );
            theAlreadyInUseNames.Add( "aName_5" );
            theAlreadyInUseNames.Add( "aName_7" );
            theAlreadyInUseNames.Add( "aName_2_1" );
            theAlreadyInUseNames.Add( "aName_2_3" );
            string theNameToBe0 = "aName";
            string theNameToBe1 = "aName_2";
            string theNameToBe2 = "aName_2_1";
            List<string> namesToBe = new List<string>();
            namesToBe.Add( theNameToBe0 );
            namesToBe.Add( theNameToBe1 );
            namesToBe.Add( theNameToBe2 );
            string[] splits;
            char[] charSeparators = new char[] { '_' };
            string theNewNameToBe1 = string.Empty;
            string theNextAvailableName = String.Empty;
            foreach ( var item in namesToBe )
            {
                splits = item.Split( charSeparators, StringSplitOptions.RemoveEmptyEntries );
                if ( splits.Length > 1 )
                {
                    int theNumber = Convert.ToInt32( splits.Last() );
                    theNewNameToBe1 = splits.ElementAt( 0 );
                    for ( int i = 1; i < splits.Length - 1; i++ )
                    {
                        theNewNameToBe1 = theNewNameToBe1 + "_" + splits.ElementAt( i );
                    }
                    int counter = 1;
                    string theActualNewName = string.Empty;
                    do
                    {
                        theActualNewName = theNewNameToBe1 + "_" + ( theNumber + counter );
                        if ( !theAlreadyInUseNames.Any( s => s.Equals( theActualNewName, StringComparison.OrdinalIgnoreCase ) ) )
                        {
                            theNextAvailableName = theActualNewName;
                            break;
                        }
                        counter++;
                    } while ( counter < int.MaxValue );
                }
                else if ( splits.Length == 1 )
                {
                        int counter = 1;
                        string theActualNewName = string.Empty;
                        do
                        {
                            theActualNewName = theNameToBe + "_" + ( counter );
                            if ( !theAlreadyInUseNames.Any( s => s.Equals( theActualNewName, StringComparison.OrdinalIgnoreCase ) ) )
                            {
                                theNextAvailableName = theActualNewName;
                                break;
                            }
                            counter++;
                        } while ( counter < int.MaxValue );
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

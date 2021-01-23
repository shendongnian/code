            {
                int GoblinKingHealth = 100;
                int GoblinKingAtk = 7;
                int GoblinKingDef = 0;
                int GoblinKingSpd = 3;
                int PlayerHealth = 100;
                int PlayerAtk = 0;
                int PlayerDef = 0;
                int PlayerSpd = 0;
                Console.WriteLine( "Chose your class." );
                Console.WriteLine( "Fighter" );
                Console.WriteLine( "Ninja" );
                Console.WriteLine( "Mage" );
                Console.WriteLine( "Knight" );
                
                while( true )
                {
                    string line = Console.ReadLine();
                    if( line == "Fighter" )
                    {
                        PlayerAtk = +4;
                        PlayerDef = +4;
                        PlayerSpd = +2;
                        Console.WriteLine( "You have chosen the Fighter class.  The Fighter class is the most well balanced class with average attack and defense and slightly under average speed" );
                        break;
                    }
                    if( line == "Ninja" )
                    {
                        PlayerAtk = +5;
                        PlayerDef = +2;
                        PlayerSpd = +4;
                        Console.WriteLine("You have chosen the Ninja class.  The Ninja class is the fastest of the classes and has above average attack but a lower defense than the fighter.");
                        break;
                    }
                    if( line == "Mage" )
                    {
                        PlayerAtk = +9;
                        PlayerDef = +0;
                        PlayerSpd = +3;
                        Console.WriteLine( "You have chosen the Mage class.  The Mage class has the strongest attack but the weakest defense and above average speed." );
                        break;
                    }
                    if( line == "Knight" )
                    {
                        PlayerAtk = +1;
                        PlayerDef = +6;
                        PlayerSpd = +1;
                        Console.WriteLine( "You have chosen the Knight class.  The Knight class has near impenitrable defense at a heavy cost of speed and attack power." );
                        break;
                    }

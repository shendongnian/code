    s
    Random rnd = new Random();
    int i;
    i = rnd.next(1,5);
    Random rnd = new Random();
    int i;
    i = rnd.next(1,5);
    int Positions[] = new Positions[5] {100, 200, 300, 400, 500};
    Tilepos1 = Positions[i];
    Tilepos2 = Positions[i];
    Tilepos3 = Positions[i];
    Tilepos4 = Positions[i];
    Tilepos5 = Positions[i]; 
    //you would hafto make up your own Tileposition and figure out how to implement it into your system
    //then make sure that the Tilepositions (Tilepos) don´t land on the same place
    if (Tilepos1 == Tilepos2)
        {
        Tilepos1 = Positions[i];
        }
    if (Tilepos1 == Tilepos3)
        {
        Tilepos1 = Positions[i];
        }
    if (Tilepos1 == Tilepos4)
        {
        Tilepos1 = Positions[i];
        }
    if (Tilepos1 == Tilepos5)
        {
        Tilepos1 = Positions[i];
        }
     //then just repeat this process with Tilepos 2, 3, 4,`int i;
    i = rnd.next(1,5);
    int Positions[] = new Positions[5] {100, 200, 300, 400, 500};
    Tilepos1 = Positions[i];
    Tilepos2 = Positions[i];
    Tilepos3 = Positions[i];
    Tilepos4 = Positions[i];
    Tilepos5 = Positions[i]; 
    //you would hafto make up your own Tileposition and figure out how to implement it into your system
    //then make sure that the Tilepositions (Tilepos) don´t land on the same place
    if (Tilepos1 == Tilepos2)
        {
        Tilepos1 = Positions[i];
        }
    if (Tilepos1 == Tilepos3)
        {
        Tilepos1 = Positions[i];
        }
    if (Tilepos1 == Tilepos4)
        {
        Tilepos1 = Positions[i];
        }
    if (Tilepos1 == Tilepos5)
        {
        Tilepos1 = Positions[i];
        }
    //then just repeat this process with Tilepos 2, 3, 4, 5
    But this would only work if the tile are squared, otherwise you could just spice things up alittle with the array.
    I hope it helped alittle and gave you a basic idea of what to do :)
 

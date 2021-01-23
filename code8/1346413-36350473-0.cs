    int myInt;
    double myDouble;
    DateTime myDateTime;
    bool r1 = int.TryParse(x, out myInt); //r1 is true if x can be parsed to int
    bool r2 = double.TryParse(x, out myDouble); //r2 is true if x can be parsed to double
    bool r3 = DateTime.TryParse(x, out myDateTime); //r3 is true if x can be parsed to DateTime

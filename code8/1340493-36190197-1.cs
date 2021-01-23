    int count = 10;
    int position = 0;
    StringBuilder Builtstring = new StringBuilder();
    foreach(string griditem in tobuild){
    if(position == count) { Builtstring.Append(griditem).Append(@"/"); position = 0; }
    else{Builtstring.Append(griditem).Append(","); position++;}}
    built = Builtstring.ToString();

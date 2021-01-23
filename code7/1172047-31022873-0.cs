    StringBuilder builder = new StringBuilder();
    builder.Append("Hello ");
    //Name
    builder.Append(Name);
    builder.Append(" ");
    builder.Append(LastName);
    builder.Append(" How are you? ");
    //First time
    if(FirstTime){
        builder.Append(" This is your first time isn't it? ");
    }
    //Bye
    builder.Append(" Bye!");
    //Convert to string
    String sentence = builder.ToString();

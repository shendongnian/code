    bool inputIsValid=false;
    do
    {
       var input=ReadInput();
       
       inputIsValid=ValidateInput(input);
    }
    while(inputIsValid==false);

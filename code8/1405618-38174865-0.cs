    void Init(){
        Print("Select Choice")
        int choice = Read()
        if(choice == 1)
        {
            Choice1()
        }
        else if(choice == 2)
        {
            Choice2()
        }
        else
        {
            InvalidChoice()
        }
    }
    void Choice1(){
        Print("Welcome to Choice1 perform action or choice")
        int choice = Read()
        if(choice == 1)
        {
            Choice2()
        }
        else if(choice == 2)
        {
            Choice3()
        }
        else
        {
            InvalidChoice()
        }
    }
    void Choice2(){
        Print("Welcome to Choice2 perform action or choice")
        int choice = Read()
        if(choice == 1)
        {
            Choice3()
        }
        else if(choice == 2)
        {
            Choice1()
        }
        else
        {
            InvalidChoice()
        }
    }
    void Choice3()
    {
        InvalidChoice()
    }
    void InvalidChoice()
    {
        Print("You died")
    }

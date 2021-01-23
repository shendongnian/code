    case 6:{//Sorting
    
                    do{
    
                        Console.WriteLine("1. Sort by Name");
                        Console.WriteLine("2. Sort by Age");
                        int choice = int.Parse(Console.ReadLine());
    
                        switch(choice){
    
                            case 1://Sort by Name
    
                                st.OrderBy(s=>s.name);
                                ok = 1;
                                break;
    
                            case 2://Sort by Age
    
                                st.OrderBy(s=>s.age);
                                ok = 1;
                                break;
    
                            default:Console.WriteLine("Not in the choices!"); ok = 0;break;
    
                        }
    
                    }while(ok != 1);}break;//case6-Sort

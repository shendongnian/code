    Class Dog
    {
        string Breed {get; set;}
        int Weight {get; set;}
    }
    
    ...
    
        Dog MyDog;
        MyDog.Breed = "Collie"; -- Exception!
        
        MyDog = new Dog();
        MyDog.Breed = "Yorkie"; --  Works.

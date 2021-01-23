    public static void SomeMethod () {
        int x = 0;
        Action bob = () => {x += 2;};
        bob();
        x += 1;
        bob();
        Console.WriteLine(x); //print (will be 5)
    }

    bool pressed = false;
    /*stuff*/
    void Update()
    {
        /*stuff*/
        if (bunnyJump)
            if (!pressed && WinApi.GetKeyState((int)Keys.Space) != 0)
            {
                Console.WriteLine("Space");
                pressed = true;
            }
            else if (pressed && WinApi.GetKeyState((int)Keys.Space) == 0)
                pressed = false;
        /*stuff*/
    }

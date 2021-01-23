    static int main(...)
    {
        System.Threading.Timer clearTimer = new System.Threading.Timer(
            (s) => { Console.Clear(); },
            null,
            5000,
            Timeout.Infinite);
        // do other stuff
    }

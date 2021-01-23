    try {
        try {
            try {
                Thread.CurrentThread.Abort();
            } catch(Exception e) {
                Console.WriteLine(e.GetType());
                throw new Exception();
            }
        } catch(Exception e) {
            Console.WriteLine(e.GetType());
        }
    } catch(Exception e) {
        Console.WriteLine(e.GetType());
    }

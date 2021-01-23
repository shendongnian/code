    public static long Ex010()
    {
        const int Limit = 2000000;
        int sqrt = (int)Math.Sqrt(Limit);
        var sum = 0L;
        var isComposite = new bool[Limit];
        for (int i = 2; i < sqrt; i++) {
            if (isComposite[i - 2])
                continue;//This number is not prime, skip
            sum += i;
            for (var x = i * i; x < isComposite.Length; x += i) {
                isComposite[x - 2] = true;
            }
        }
        //Add the remaining prime numbers
        for (int i = sqrt; i < Limit; i++) {
            if (!isComposite[i - 2]) {
                sum += i;
            }
        }
        return sum;
    }

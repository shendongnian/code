    static void Main(string[] args) {
        const int height = 4;
        for(int row = 0; row < height; row++) {
            //left padding
            for(int col = 0; col < height - row - 1; col++) {
                Console.Write(' ');
            }
            //digits
            for(int col = 0; col < row * 2 + 1; col++) {
                Console.Write((char)('1' + row));
            }
            //right padding (is this needed?)
            for(int col = 0; col < height - row - 1; col++) {
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }

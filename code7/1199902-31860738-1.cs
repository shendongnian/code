    static void Main(string[] args) {
        string text = "#filenameid#30day#Name#.xls";
        int frameStart = 0;
        int match = 0;
        // loop on characters
        for(int i = 0; i < text.Length; i++) {
            char c = text[i];
            switch(c) {
                case '#':
                    // evaluate frame (text between meshes)
                    switch(match) {
                        // match at index 1
                        case 1:
                            Console.Write("filenameid=");
                            Console.WriteLine(text.Substring(frameStart, i - frameStart));
                            break;
                        // match at index 3
                        case 3:
                            Console.Write("name=");
                            Console.WriteLine(text.Substring(frameStart, i - frameStart));
                            break;
                    }
                    // move to next frame
                    frameStart = i + 1;
                    match++;
                    break;
            }
        }
        // count of matches is match + 1
        Console.ReadKey();
    }

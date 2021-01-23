    using (var log = CreateText("log.txt"))
    using (var result = CreateText("result.txt")) {
        foreach (string line in ReadLines("source file")) {
            if (line.Lenth > 0) {
                if (Char.IsDigit(line[0])) {
                    result.WriteLine(line);
                } else {
                    log.WriteLine(line);
                }
            }
        }
    }

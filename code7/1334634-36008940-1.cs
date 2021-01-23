    // you can do precise powering if needed
    double number_of_variations = Math.Pow(count, count); 
    T[] result = new T[count];
    for (int i = 0; i < number_of_variations; ++i) {
        int x = i;
        for (int j = 0; j < count; ++j) {
            result[j] = elements[x % count];
            x /= count;
        }
        // do something with one of results
    }

        TextWriter writeToNewFile = new StreamWriter (newFileDestination);
        for(int a = 1; a < 56; a++){
            for(int b = 1; b < 56; b++){
                for(int c = 1;  c < 56; c++){
                    for(int d = 1; d < 56; d++){
                        for(int e = 1;  e < 56; e++){
                            for(int f = 1; f < 56; f++){
                                if(a != b && a != c && a != c && a != e && a != f && b != c && b != d && b != e && b != f && c != d && c != e && c != f && d != e && d != f && e != f){
                                    word = word2;
                                    numbers = string.Concat(a, separator,  b, separator, c, separator, d, separator, e, separator, f);
                                    word += numbers;
									writeToNewFile.WriteLine(word);
									Console.WriteLine (word);
									wordCount++;
                                }
                            }
                        }
                    }
                }
            }
        }

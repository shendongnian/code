    string cubeinline = "12345123451234X1234512345";
    List<string> cube = new List<string>(){ "12345",
                                        "12345",
                                        "1234X",
                                        "12345",
                                        "12345"};
    bool isEqual = cubeinline == string.Concat(cube);

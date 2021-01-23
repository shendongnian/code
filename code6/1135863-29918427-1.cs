    void RespondToAction(string input) {
        try {
            SomeOperation(input);
        }
        catch (FormatException e) {
            throw new CustomException("Invalid input format.", e);
        }
        // Note you do not catch CustomException here...
        // Note you do not use try-catch here...
        serviceC.CreateFile();
    }

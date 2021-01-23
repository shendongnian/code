    private int GetNumberOfUnits() {
        int numberOfUnits;
        if (!int.TryParse(Console.ReadLine(), out numberOfUnits)) {
            Console.WriteLine("Sorry... I didn't understand that.  I'm going to assume you have the expected 20 units.");
            numberOfUnits = 20;
        }
        return numberOfUnits;
    }
    bool IsValidGrade(string grade) {
        string [] validGrades = {"D","M","P"};
        return validGrades.Contains(grade.ToUpper());
    }
    private int GetScoreFromGrade(string grade) {
        switch (grade.ToUpper()) {
            case "P":
                return 20;
            case "M":
                return 40;
            case "D":
                return 80;
        }
        throw new InvalidOperationException(string.Format("Tried to get a score from an invalid grade {0}", grade));
    }

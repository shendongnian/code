    public void GetAllStudentGrades() {
        while (true) {
            string studentName = PromptStudentAndGetName();
            if (studentName.ToUpper() == "EXIT") {
                return;
            }
            List<string> studentGrades = GetStudentGrades();
            int score = CalculateScoreFromGrades(studentGrades);
            string finalGrade = CalculateGradeFromScore(score);
            PrintFinalStatement(studentName, finalGrade);
        }
    }

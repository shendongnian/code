     public int EstimateGrade(int[] grade)
    {
        int sum = (grade[0] + grade[1] + grade[2]) * 85;
        int result = sum % 101;
        return result;
    }

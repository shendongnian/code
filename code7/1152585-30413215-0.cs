    // Note: public fields are almost *always* a bad idea
    private readonly Student[] students;
    public University(int numberOfStudents)
    {
        students = new Student[numberOfStudents];
        for (int i = 0; i < numberOfStudents; i++)
        {
            students[i] = new Student();
        }
    }

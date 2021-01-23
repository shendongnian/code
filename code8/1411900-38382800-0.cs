    private void Semester_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Semester.Score)) {
            student.SemesterScore = semester.Score;
        }
    }

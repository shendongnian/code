    public SubjectRow (Form f, int pointX=100, int pointY=300)
    {
        counter++;
        subjectBox.Location = new Point(pointX, pointY);
        f.Controls.Add(subjectBox);
    }
    SubjectRow test= new SubjectRow (this,100,300); // You can control position of every control

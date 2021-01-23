    public string GetPrimaryMajor(List<Student> students)
    {
        //Create a dictionary of string and int. These are our major names and and the count of students in thaat major respectively
        Dictionary<string, int> MajorCounts = new Dictionary<string, int>();
        //Iterate through all students
        foreach (Student stu in students)
        {
            //Check if we have already found a student with that major
            if (MajorCounts.ContainsKey(stu.Major))
            {
                //If yes add one to the count of students with that major
                MajorCounts[stu.Major]++;
            }
            else
            {
                //If no create a key for that major, start at one to count the student we just found
                MajorCounts.Add(stu.Major, 1);
            }
        }
        //Now that we have our majors and number of students in each major we need to find the highest one
        //Our first one starts as our highest found
        string HighestMajor = MajorCounts.First().Key;
        //iterate through all the majors
        for (int i = 0; i < MajorCounts.Count(); i++)
        {
            //If we find a major with higher student count, replace our current highest major
            if (MajorCounts.ElementAt(i).Value > MajorCounts[HighestMajor])
            {
                HighestMajor = MajorCounts.ElementAt(i).Key;
            }
        }
        //Return the highet major
        return HighestMajor;
    }

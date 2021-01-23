    decimal grade3 = 5.80m;
    decimal grade4 = 2.10m;
    decimal average1 = (grade3 + grade4) / 2;
    int grade1 = 580;
    int grade2 = 210;
    var average = (grade1 + grade2) / 2;
    string result = string.Format("{0:0.0}", average / 100);  // 3.0
    Debug.WriteLine(result);
    // or when good enough is not enough 
    decimal avg = ((decimal)grade1 + (decimal)grade2) / 200m;  // 3.95
    Debug.WriteLine(avg);
    Debug.WriteLine(string.Format("{0:0.0}", avg));  // 4.0

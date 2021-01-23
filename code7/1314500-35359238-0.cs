    while (true) {
        Sec = DateTime.Now.Second;
        if (Hour == 23 && Min == 59 && Sec == 59){
            Hour = 0;
            Min = 0;
        } else if (Min == 59 && Sec == 59){
            Min = 0;
            Hour += 1;
        } else if (Sec == 59) {
            Min += 1;
        } 
        yield return new WaitForSeconds (1f);
    }

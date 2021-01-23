    // Use this for initialization
    string FileName;
    public void Start()
    {
        FileName = UIManagerScript.SUBJECTID + "FeedbackGameData444.csv";
        //create file (txt or csv) with streamwriter which has the name of the Subject and Information which game
        //and write headers to file 
        WriteToFile(FileName, true, "PositionRingFeeback" + "," + "PositionSphereMiddle" + "," + "distanceRingFeedbackTOSphere" + "," + "Collisions" + "," + "Timer" + System.Environment.NewLine);
    }
    public void SaveDataFeedback()
    {
        //start writing in file only when feedback game is starting 
        //if (StartButtonManager.startingGame) {
        if (StartButtonManager.startingGame)
        {
            //get position of center of the ring
            PositionRingFeedback = GameObject.Find("Ring").transform.position;
            //position of the center of the ring (y axis) 
            PositionRINGFeedback = PositionRingFeedback.y;
            //error, meaning difference between position of the spheremiddle and center of the ring 
            distanceRingFeedbackTOSphere = PositionRINGFeedback - Sinewave.posSpheremiddle;
            //write data to file _ columns are separated by a , 
            WriteToFile(FileName, false, PositionRINGFeedback + "," + Sinewave.posSpheremiddle + "," + distanceRingFeedbackTOSphere + "," + CounterManager.counterHitSinewave + "," + UIManagerScript.myTimer + System.Environment.NewLine);
        }
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        //saves the data from the FeedbackGame every Frame 
        SaveDataFeedback();
    }
    private void WriteToFile(string fileName, bool createNew, string contents)
    {
        if (createNew)
            File.WriteAllText(fileName, contents);
        else
            File.AppendAllText(fileName, contents);
    }

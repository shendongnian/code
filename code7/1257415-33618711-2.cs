    public void PJRating_Click(object sender, RoutedEventArgs e)
    {
        // Init your transfer object
        var sfp = new SecondFormParams();
        //This block reads in user text box submissions
        mys = Convert.ToDouble(MYS.Text);
        tubeOD = Convert.ToDouble(TubeOD.Text);
        tubeID = Convert.ToDouble(TubeID.Text);
        tjOD = Convert.ToDouble(TJOD.Text);
        sfp.ArgumentOne = ((Math.Pow(((((tubeOD - tubeID) * 0.95) + tubeID)), 2) - Math.Pow(tubeID, 2)) * (Math.PI / 4)) * (mys * Math.Pow(10, 3));
        sfp.ArgumentTwo = "Yo man, do something with me on the next form";
        //Diplay the new window
        PupJointRating newTensileRating = new PupJointRating(sfp);
        newTensileRating.Show();
    } 

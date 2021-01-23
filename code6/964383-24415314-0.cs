        public void Vision()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
    
                try
                {
        
                    AlignmentParams.ApproximateNumberToFind = 1;
                    AlignmentParams.SearchRegionMode = 0;
                        AlignmentResult = AlignmentPat.Execute(cogDisplay1.Image as CogImage8Grey, null , AlignmentParams);
                    Fixture.InputImage = cogDisplay1.Image;
                    Fixture.RunParams.UnfixturedFromFixturedTransform = AlignmentResult[0].GetPose();
                    Fixture.Run();
                    AlignmentResult = null;
      
                // your coding stuff
         
                        sw.Stop();
                        SetText("V" + sw.ElapsedMilliseconds.ToString() + Environment.NewLine);
          
                }
                catch (Exception err) 
                {
        
                   SetText(Environment.NewLine + "***********Error***********" + Environment.NewLine);
                   SetText(err.ToString() + Environment.NewLine);
                   SetText("***************************" + Environment.NewLine);
                }
    finally{Fixture.InputImage=null}

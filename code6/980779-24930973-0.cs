            RTBOX.Inlines.Add("hello ");
            Run run = new Run("my ");         
            run.FontWeight = FontWeights.Bold;
            Run run1 = new Run("faithfull\n ");
            Run run2 = new Run("sdsf ");
            Run run3 = new Run("Computer");           
            run3.TextDecorations = TextDecorations.Underline;
            Run run4 = new Run(" You rock !");
            run4.FontStyle = FontStyles.Italic;
      
            RTBOX.Inlines.Add(run);
            RTBOX.Inlines.Add(run1);
            RTBOX.Inlines.Add(run2);
            RTBOX.Inlines.Add(run3);
            RTBOX.Inlines.Add(run4);

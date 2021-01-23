            // here's checking a selection of buttons against the complete enum universe of values
            var lastButton = Convert.ToInt32(Enum.GetValues(typeof(Buttons)).Cast<Buttons>().Max());
            int enumCheck;
    
            Buttons flags = Buttons.Ok | Buttons.SaveNew | Buttons.Load | Buttons.No | Buttons.Submit | Buttons.Exit;
    
            for (int i = 0; Math.Pow(2, i) <= lastButton; i++)
            {
                enumCheck = (int)Math.Pow(2, i);
    
                if ((flags & (Buttons)enumCheck) == (Buttons)enumCheck)
                {
                    Debug.WriteLine(Enum.GetName(typeof(Buttons), enumCheck));
                }
            }

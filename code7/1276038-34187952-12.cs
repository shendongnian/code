            LiftingStory obj = new LiftingStory();
            obj.Weight = string.Empty;
            obj.Date = string.Empty; //put values from comboBoxes
            obj.Reps = string.Empty;
            obj.Lift = string.Empty;
            obj.Week = string.Empty;
            BusinessLiftingStory busObj = new BusinessLiftingStory();
            busObj.insertLifting(obj);

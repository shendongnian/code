    class Fun {
        void HaveSomeFun(bool summers) {
            string waterGun = <Some Value>
            string jacket = <Some Other Value>
    
            ArgumentValidationHelper.ValidateNotNullOrEmpty("WaterGun", waterGun);
            ArgumentValidationHelper.ValidateNotNullOrEmpty("Jacket", jacket);
    
            if(summers) {
                Console.WriteLine("Using {0}", waterGun);
            } 
    		else {
                Console.WriteLine("Using {0}", jacket);
            }
        }
    }

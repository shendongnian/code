        bool IsStartValid;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value > MaxValidDate)
                {
                    IsStartValid = false;
                    throw new Exception("Error");//***
                }
                else
                    IsStartValid = true;
               startDate=value;
            }
        }

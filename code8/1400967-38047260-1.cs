    class Program
        {
            static void Main(string[] args)
            {
    
                string source = @"Transaction ID : 100000527054518 PNR No. : 6755980353 Train No. / Name : 18615 / KRIYA YOGA EXP Date of Booking : 07-Jun-2016 Class : SLEEPER CLASS : GENERAL Date of Journey : 13-Jun-2016 From : HWH To : RNC Boarding At : HWH Date Of Boarding : 13-Jun-2016 Reservation Up to : RNC Distance : 416 KM Scheduled Departure : 22:10 Scheduled Arrival : 14-Jun-2016 ( 07:05 Hrs ) Total Fare : ? 500.0 & SC : ? 23.0 Adult : 2 & Child : 0 Details of Passengers S.No.Name
                                Age Gender Concession Status Coach Seat / Berth / WL No Current Status Coach Seat / Berth / WL No ID Type / ID No. 1 AYAN PAL 40 Male CNF S7 49(LB) CNF S7 49(LB)";
    
                MyClass mc1 = new MyClass();
    
                mc1.getObjectFromString(source);
            }
    
        }
    
    
        class MyClass
        {
            public string TransactionID { get; set; }
            public string pnrno { get; set; }
            public string trainno { get; set; }
            public string dateofbooking { get; set; }
            public string className { get; set; }
            public string Quota { get; set; }
    
            public void getObjectFromString(string source)
            {
    
                Regex transactionRegex = new Regex(@"Transaction ID : [0-9]+ PNR No.");
                Regex pnrnoRegex = new Regex(@"PNR No. : [0-9]+ Train No. / Name");
                Regex trainnoRegex = new Regex(@"Train No. / Name : [0-9]*[A-Za-z/ ]* Date of Booking");
                Regex dateofbookingRegex = new Regex(@"Date of Booking : [-0-9a-zA-Z/ ]* Class");
                Regex classNameRegex = new Regex(@"Class : [A-Za-z ]* CLASS");
                Regex QuotaRegex = new Regex(@"CLASS : [A-Za-z ]* Date of Journey");
    
                Match match = transactionRegex.Match(source);
                if (match.Success)
                    this.TransactionID = match.Value.Replace("Transaction ID :", "").Replace("PNR No.", "");
    
                match = pnrnoRegex.Match(source);
                if (match.Success)
                    this.pnrno = match.Value.Replace("PNR No. :", "").Replace("Train No. / Name", "");
    
                match = trainnoRegex.Match(source);
                if (match.Success)
                    this.trainno = new String(match.Value.Replace("Train No. / Name :", "").Replace("Date of Booking", "").ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
    
                match = dateofbookingRegex.Match(source);
                if (match.Success)
                    this.dateofbooking = match.Value.Replace("Date of Booking :", "").Replace("Class", "");
    
                match = classNameRegex.Match(source);
                if (match.Success)
                    this.className = match.Value.Replace("Class :", "").Replace("CLASS", "");
    
                match = QuotaRegex.Match(source);
                if (match.Success)
                    this.Quota = match.Value.Replace("CLASS :", "").Replace("Date of Journey", "");
    
            }
        }

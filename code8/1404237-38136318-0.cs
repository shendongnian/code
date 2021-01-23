    //Dictionaries for the different air properties
                    //Air properties for T=0
            Dictionary<string, double> a = new Dictionary<string, double>();
            {
                a.Add("T",0);
                a.Add("Rho", 1.293);
                a.Add("Cp", 1.005);
                a.Add("k", 0.0243);
                a.Add("Nu", 13.30*Math.Pow(10,-6));
                a.Add("Betta", 3.67 * Math.Pow(10, -3));
                a.Add("Pr", 0.715);
            }
                //Air properties for T=20
            Dictionary<string, double> b = new Dictionary<string, double>();
            {
                b.Add("T", 20);
                b.Add("Rho", 1.205);
                b.Add("Cp", 1.005);
                b.Add("k", 0.0257);
                b.Add("Nu", 15.11 * Math.Pow(10, -6));
                b.Add("Betta", 3.43 * Math.Pow(10, -3));
                b.Add("Pr", 0.713);
            }
             //Air properties for T=40
            Dictionary<string, double> c = new Dictionary<string, double>();
            {
                c.Add("T", 40);
                c.Add("Rho", 1.127);
                c.Add("Cp", 1.005);
                c.Add("k", 0.0271);
                c.Add("Nu", 16.97 * Math.Pow(10, -6));
                c.Add("Betta", 3.20 * Math.Pow(10, -3));
                c.Add("Pr", 0.711);
            }
            //temporary values for example
            double T = 25;
            double Rho=0;
           
            // Code for property lookup
            if (T <= a["T"])
            {
                Rho = a["Rho"];
            }
            else if (T == b["T"])
            {
                Rho = b["Rho"];
            }
            else if (T < c["T"])
            {
                Rho = (T - b["T"]) * (c["Rho"] - b["Rho"]) / (c["T"] - b["T"]) + b["Rho"];
            }
            else
                Rho = c["Rho"];

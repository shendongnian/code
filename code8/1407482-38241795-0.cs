    using System.Text.RegularExpressions;
    
    string pattern = @"Page [0-9]+ of ([0-9]+) [A-Z][a-z]+ [0-9]+ ([0-9A-Za-z-]+) ([0-9][0-9]\/[0-9][0-9]\/[0-9]+)";
    
    Regex r = new Regex(pattern);
    MatchCollection mc = r.Matches("Unit Code : Billing Period : Billing Date : Due Date : Total Amount Due : STATEMENT OF ACCOUNT Page No.: Page 1 of 2 July 2016 1S-D-0303 07/07/2016 JOHN DOE Unit 303D, Building name, CITY NAME");
